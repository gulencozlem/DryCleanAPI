using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string ProductCountOfCategoryError = "Aynı kategoriden sadece 10 ürün olmalı";
        public static string ProductNameAlreadyExist = "Ürün adı zaten mevcut";

        public static string CategoryLimitExceded = "Ürün kategorisi limiti aşıldığı için ürün eklenemiyor";

        // ProductImage
        public static string ProductImageAdded = "Ürün resmi eklendi";
        public static string ProductImageUpdated = "Ürün resmi güncellendi";
        public static string ProductImageDeleted = "Ürün resmi silindi";
        public static string ProductImageListed = "Ürün resmimleri listelendi";

        public static string ProductImageLimitAchieved = "Bir ürün için en fazla 5 resim yüklenebilir";
        public static string ProductImageNotFound = "Ürün resmi bulunamadı";
        public static string ProductNotFound = "Ürün bulunamadı";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt Olundu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";

        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";

        public static string AccessTokenCreated = "Giriş Başarılı";

        public static string ProductListed = "Ürünler Listelendi";
        public static string CategoryListed = "Kategoriler Listelendi";
        public static string CategoryAdded = "Ketegori Eklendi";
        public static string CategoryUpdated = "Kategori Güncellendi";
        public static string CategoryDeleted = "Kategori Slindi";


        //Order
        public static string OrderAdded = "Sipariş başarıyla eklendi";
        public static string OrderDeleted = "Sipariş başarıyla silindi";
        public static string OrderUpdated = "Sipariş başarıyla güncellendi";
        public static string OrdersListed = "Siparişler Listelendi";

        //User
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";

        //Customer
        public static string customerAdded = "Müşteri Eklendi";
        public static string customerDeleted = "Müşteri Silindi";
        public static string customersListed = "Müşteriler Listelendi";
        public static string customerUpdated = "Müşteri Güncellendi";
    }
}