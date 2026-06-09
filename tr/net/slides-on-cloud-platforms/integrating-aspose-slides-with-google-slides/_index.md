---
title: Aspose.Slides'ı Google Slides ile Entegre Etme
linktitle: Google Slides
type: docs
weight: 50
url: /tr/net/integrating-aspose-slides-with-google-slides/
keywords:
- bulut platformları
- bulut entegrasyonu
- Google Slides
- Google Drive
- Google API
- Google Servis Hesabı
- SaaS entegrasyonu
- OAuth 2.0
- PPT'den PDF'ye
- PowerPoint otomasyonu
- sunum işleme
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides'ı Google Slides ile bağlayarak sunumları içe aktarın, senkronize edin ve dönüştürün, iş akışlarını otomatikleştirin ve PowerPoint ile OpenDocument'i tek bir iş akışında tutun."
---
## **Giriş**

Aspose.Slides artık Google Slides ve Google Drive ile entegrasyon sağlayarak [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) aracılığıyla .NET uygulamalarının Google Slides sunumlarını dönüştürmesini, düzenlemesini, indirmesini ve yüklemesini mümkün kılar.

## **Google Slides Nedir?**
[Google Slides](https://workspace.google.com/products/slides/tr/) Google tarafından geliştirilen ücretsiz, web tabanlı bir sunum yazılımıdır. Kullanıcıların Microsoft PowerPoint'e benzer şekilde çevrimiçi slayt sunumları oluşturmasına, düzenlemesine ve paylaşmasına olanak tanır. Gerçek zamanlı işbirliğini, bulut depolamayı destekler ve internet erişimi olan herhangi bir cihazda çalışır.

## **Google API**
Aspose.Slides aracılığıyla Google Slides sunumunuzla çalışmaya başlamadan önce bir Google API projesi oluşturmalı ve bir [Google Cloud projesi](https://developers.google.com/workspace/guides/create-project) oluşturmalısınız, ardından istediğiniz API'leri etkinleştirin.

Ardından Google API'ye erişim yöntemini seçmelisiniz - [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) Google API'ye erişmek için iki yöntemi destekler:
- `Google Service Account`
- `OAuth 2.0` kullanıcı etkileşimiyle bir tarayıcı üzerinden.

### **Google Service Account**
Service hesabı, uygulamalar veya sunucular tarafından kullanıcı etkileşimi olmadan programlı olarak Google API'lerine erişmek için kullanılan özel bir Google hesabıdır. Genellikle arka uç sistemleri veya otomatik görevler için kullanılır. Service hesapları, bir JSON anahtar dosyasıyla kimlik doğrulaması yapılır ve kendi e-posta adreslerine sahiptir. [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) aracılığıyla belirli izinler atanabilir ve genellikle Google Drive, Sheets veya BigQuery gibi API'lerle güvenli, otomatik kaynak erişimi sağlamak için kullanılır.

### **OAuth 2.0**
Google API'lerine erişmenin bir diğer yaygın yolu, kullanıcı etkileşimiyle bir tarayıcı üzerinden OAuth 2.0 kullanmaktır. Bu akışta, kullanıcı izni vermesi için bir Google oturum açma sayfasına yönlendirilir. Onaylandıktan sonra, uygulama bir yetkilendirme kodu alır ve bu kodu bir erişim belirteci ve bir yenileme belirteci almak için değiştirir. Erişim belirteci, Google API'lerine geçici erişim sağlar, yenileme belirteci ise depolanıp yeniden kullanılabilir; böylece kullanıcı tekrar oturum açmadan yeni erişim belirteçleri alınabilir. Bu, tarayıcı etkileşiminin yalnızca bir kez gerekli olduğu ve sonraki API erişimlerinin tamamen otomatik olduğu anlamına gelir. Bu yöntem, genellikle bir kullanıcının izniyle Google Slides veya Drive dosyalarına erişmesi gereken uygulamalar için kullanılır.

## **Kod Yazalım**
İlk olarak, projenize [Aspose.Slides SaaS Integration NuGet paketi](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) ekleyin:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **Örnek 1**
Aşağıdaki örnekte, Google Drive'dan bir Google Slides sunumunu indirip yerel diske PDF dosyası olarak kaydedeceğiz. Yetkilendirme için bir Google Service Account kullanacağız; kimlik bilgilerinin bulunduğu service account JSON dosyasının zaten indirildiğini varsayıyoruz.

```csharp
// Dışarıdan yönetilen HttpClient oluştur
HttpClient httpClient = new HttpClient();

// Service account JSON dosyası kullanarak bir yetkilendirme sağlayıcısı oluştur
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Yetkilendirme sağlayıcısı ile Google Slides entegrasyon hizmetini başlat
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Google Drive'dan dosya kimliğiyle bir sunumu Aspose.Slides IPresentation örneğine yükle
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Gerekirse sunumu değiştir (ör. ikinci slaytı kaldır)
pres.Slides.RemoveAt(1);

// Sunumu yerel olarak PDF dosyası olarak kaydet
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

Kolaylık sağlamak için, Aspose.Slides SaaS Integration, kullanıcıya mevcut tüm dosyaları listeleme yöntemi sunar. Dönen veri dosya adı, MIME türü ve dosya kimliğini içerir.

```csharp
// Sağlanan hizmet hesabı için mevcut dosyaların listesini al
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

Dosya kimliğini bulmanın bir diğer yolu, sunumu Google Slides web uygulamasında açıp URL içinde bulmaktır.

Örneğin, aşağıdaki URL'de:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

Dosya kimliği:

```
1A2B3C4D5E6F7G8H9I0J
```

## **Örnek 2**
Sonraki örnekte, sıfırdan bir PowerPoint sunumu oluşturup Google Slides formatında Google Drive'a yükleyeceğiz. Yetkilendirme için OAuth 2.0 kullanacağız.

```csharp
// Harici yönetilen HttpClient oluştur
HttpClient httpClient = new HttpClient();

// OAuth ile istemci kimliği ve istemci gizliliği kullanarak bir yetkilendirme sağlayıcı oluştur
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Yetkilendirme sağlayıcısı ile Google Slides entegrasyon hizmetini başlat
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Örnek bir sunum oluştur
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Sunumu Google Drive kök klasörüne Google Slides formatında kaydet
    // Aspose.Slides tarafından desteklenen başka bir dışa aktarma formatını da seçebilirsiniz
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

Uygulamanızda bu tür bir yetkilendirme kullanıyorsanız `tarayıcı etkileşimi gerekir`. Hesabınızı seçmeniz ve uygulamanın Google Drive API'nıza erişmesine izin vermeniz gerekir. Bu kadar—bu işlem yalnızca ilk çalıştırmada gereklidir.

### **Örnek 3**
Aşağıdaki örnekte önceden elde edilmiş erişim belirtecini kullanacağız. `GoogleAccessTokenAuthProvider`, mevcut bir OAuth 2.0 erişim belirtecini Google API'lerine istek yetkilendirmesi için kullanan `IGoogleAuthorizationProvider` arayüzünün bir uygulamasıdır. OAuth akışını başlatan veya yöneten sağlayıcılardan farklı olarak, bu sınıf geçerli bir erişim belirtecini çağırıcı tarafından sağlanmasına dayanır. Bu sağlayıcı, erişim belirtecinin dışarıdan elde edildiği—genellikle bir ön uç uygulaması veya başka bir hizmet tarafından—ve arka uca iletildiği sistemlerde kullanışlıdır. Yenileme belirteçlerinin sunucu tarafında yönetilmesinin karmaşıklık getirdiği veya eşzamanlı yenileme denemeleri nedeniyle belirtecin geçersizleşme riskine sebep olduğu dağıtık ortamlar için özellikle uygundur. Bu örnek, dosya kimliğini koruyarak bir dosyayı nasıl değiştireceğinizi ve Google Drive'da adını nasıl güncelleyeceğinizi gösterir.

```csharp
// İstek yapmak için bir HTTP istemcisi oluştur
using HttpClient httpClient = new HttpClient();

// Erişim tokenı kullanarak Google Drive kimlik doğrulamasını ayarla
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Kimlik doğrulama ve HTTP istemcisini kullanarak Google Slides/Drive entegrasyonunu başlat
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Aspose.Slides kullanarak örnek bir sunum oluştur
using (var presentation = new Presentation())
{
    // İlk slayta bir dikdörtgen şekil ekle ve metnini ayarla
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Belirli kalite ve uyumluluk ayarlarıyla PDF kaydetme seçeneklerini tanımla
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Google Drive'daki mevcut dosyayı dosya kimliğiyle kaydet (değiştir), adını güncelle ve PDF olarak dışa aktar
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // Google Drive'daki mevcut dosyanın kimliği
        GoogleSaveFormatType.Pdf,         // Kaydedilecek istenen format
        saveOptions,           
        "NewFileName.pdf"                 // Dosyaya atanacak yeni ad
    );
}
```

## **Özet**
Aspose.Slides artık yönetim için ek bir dosya formatını destekleyerek, sunumları oluşturma, paylaşma ve düzenleme için bulut tabanlı iş akışlarının otomasyonunu basitleştiriyor.

Bu makale temel özellikleri kapsadı. Dosyaları alt klasörlere kaydedebilir, mevcut dosyaları değiştirebilir ve çeşitli formatlarda—Google Slides sunumlarıyla sınırlı olmamak üzere—Google Drive'a dışa aktarabilirsiniz.

Aspose.Slides SaaS Integration, sunum SaaS platformları desteğini genişletmeye devam edecek, bu yüzden gelecekteki güncellemeler için tekrar kontrol edin.

## **FAQ**

**Bu entegrasyonu kullanmak için bir Google Workspace hesabına ihtiyacım var mı?**  
Hayır. Ücretsiz bir Google hesabı ya da bir Google Workspace hesabı kullanabilirsiniz. Gerekli erişim, Google Drive ve Slides izinlerinize bağlıdır.

**Hangi kimlik doğrulama yöntemini seçmeliyim—Service Account mı yoksa OAuth 2.0 mı?**  
**Service Account**'u, kullanıcı etkileşimi olmadan arka uç veya otomatik iş akışları için kullanın. **OAuth 2.0**'ı, belirli bir kullanıcının izniyle Google Slides veya Drive dosyalarına erişmeniz gerektiğinde kullanın.

**Google Slides dışındaki formatlarla çalışabilir miyim?**  
Evet. Aspose.Slides, Google Drive'a yüklemeden önce sunumları çeşitli formatlarda (ör. PDF, PPTX, HTML) kaydetmenize olanak tanır.

**Google Slides sunumunun dosya kimliğini nasıl alabilirim?**  
`GetDriveFileInfosAsync()` yöntemini kullanarak veya Google Slides'teki sunumun URL'sinden kopyalayarak alabilirsiniz.

**Entegrasyon, Google Drive'da mevcut bir dosyanın değiştirilmesini destekliyor mu?**  
Evet. Dosya kimliğini koruyarak bir dosyayı güncellemek için `SavePresentationToExistingFileAsync` yöntemini kullanın.

**OAuth 2.0 kullanırken tarayıcı etkileşimi her seferi gerekli mi?**  
Hayır. Tarayıcı etkileşimi sadece ilk yetkilendirme sırasında gereklidir. Sonrasında, depolanan yenileme belirteçleri otomatik erişime izin verir.