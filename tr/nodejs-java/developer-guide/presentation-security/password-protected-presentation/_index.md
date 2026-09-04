---
title: JavaScript'te Sunumları Şifreyle Koruma
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/nodejs-java/password-protected-presentation/
keywords:
- şifreli sunum
- açma şifresi
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum şifresi doğrulama
- sunum şifresini kontrol et
- şifreli sunumu aç
- şifrelemeyi kaldır
- PowerPoint
- PPT
- PPTX
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides ile şifreli PowerPoint PPT ve PPTX sunumlarını şifreleyin, algılayın, doğrulayın, açın ve şifrelerini çözün."
---
## **Genel Bakış**

Açma şifresi bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru şifre gerekir; bu koruma gizliliği sağlar.

Açma şifresi, yazma koruma şifresinden farklıdır. Yazma koruması değişikliği kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için şifreleri yönetmek amacıyla [Sunumları Yazma Koruması](/slides/tr/nodejs-java/write-protected-presentation/) bölümüne bakın.

Aşağıdaki işlem akışları hem PPT hem de PPTX sunumları için geçerlidir. Örneklerde dosya tabanlı ve akış tabanlı davranışların önemli olduğu her iki format da kullanılmıştır.

## **Açma Şifresi ile Sunumu Şifreleme**

Açma şifresi atamak için [ProtectionManager.encrypt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#encrypt) yöntemini kullanın. Ardından şifreli sunumu kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) yöntemini çağırın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Belge Özelliklerini Açık Tutma**

Varsayılan olarak Aspose.Slides, sunum şifrelemesinde belge özelliklerini de içerir. Bu davranışı slayt içeriği şifrelemesinden bağımsız olarak kontrol eden [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) yöntemi vardır. Bir indeksleme, sınıflandırma, arama veya belge yönetim sistemi, açma şifresi olmadan meta verileri okuması gerektiğinde, [ProtectionManager.encrypt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#encrypt) çağrısından önce `false` geçirin.

Aşağıdaki örnek, yerleşik belge özellikleri açık bırakılarak bir PPTX sunumunu şifreler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) yöntemine `false` geçirilmesi, slaytlar, ana slaytlar, düzenler, şekiller, medya veya diğer sunum içeriğini açık yapmaz. Sadece belge özelliklerini etkiler. Şifreli içeriği yüklemeden bu özellikleri okumak için [Sunum Özelliklerini Yönetme](/slides/tr/nodejs-java/presentation-properties/) bölümüne bakın.

## **Şifreli Sunumu Yükleme**

[LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) özelliğini açma şifresiyle ayarlayın ve dosyayı yüklerken bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yapıcısına geçirin. Açma şifresi gerektiğinde fakat verilen şifre eksik ya da hatalıysa yükleme başarısız olur.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Şifre çözülmüş sunumla çalış.
} finally {
    presentation.dispose();
}
```

## **Sunumdan Şifreyi Kaldırma**

Sunumu açma şifresiyle yükleyin, [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum artık şifre yoluyla yüklenemez.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Yüklemeden Önce Açma Şifresini Doğrulama**

Tam bir sunum örneği oluşturmadan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) yöntemini kullanarak [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) alın. Şifre isteyip istemediğini kontrol etmek için [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) özelliğine bakın. Koruma varsa, sağlanan değeri [PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#checkPassword) yöntemiyle doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyasının açma şifresini doğrular, doğrulanan değeri [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) metoduna geçirir ve ardından tam sunumu yükler:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Akış İş Akışı**

[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) yöntemini kullanarak bir Node.js okunabilir akışını inceleyin. İnceleme akışı tüketildikten sonra, tam sunumu [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) yöntemiyle yüklemeden önce yeni bir akış oluşturun.

Aşağıdaki örnek bir PPT dosyası için verilmiştir:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword Dönüş Değerleri**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#checkPassword) yalnızca sunumda bir açma şifresi varsa ve sağlanan şifre doğruysa `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Şifre hatalıdır.
- Sunumda bir açma şifresi yoktur.
- Sağlanan şifre `null` ya da boş'tur.

Davranış PPT ve PPTX sunumları için aynıdır.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru şifreyle bir sunumu yükledikten sonra, kaynağın şifreli olduğunu doğrulamak için [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) özelliğini denetleyin. Açma şifresi korumasını yüklemeden önce tespit etmek için yukarıda gösterildiği gibi [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) yöntemini kullanın.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Güvenlik Önerileri**

{{% alert color="warning" title="Security" %}}
Açma şifrelerini loglamayın ya da tanılayıcı mesajlarda gösterin. Gereksiz tekrar doğrulama denemelerinden kaçının, şifreleri sadece gerektiği süre boyunca bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.

Açık belge özellikleri, sunum içeriği şifrelenmiş olsa bile yazar adları, başlıklar, konu, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerler gibi bilgileri ifşa edebilir. Hassas meta verileri sunumla birlikte şifreleyin. Özellikleri açık bırakmak, dosyanın indekslenmesi, sınıflandırılması, aranması veya şifre olmadan yönetilmesi gerektiğinde açıkça kararlaştırılmış bir durum olmalıdır.
{{% /alert %}}

## **Çevrimiçi Sunumu Şifreleme**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
2. Sunumu seçin ya da yükleyin.
3. Görüntüleme koruması için bir şifre girin.
4. İsterseniz düzenleme koruması için ayrı bir şifre girin.
5. Koruma işlemini uygulayın ve oluşan dosyayı indirin.

{{% alert color="info" title="See also" %}}
- [Sunumları Yazma Koruması](/slides/tr/nodejs-java/write-protected-presentation/)
- [PowerPoint’te Dijital İmza](/slides/tr/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açma şifresi sunumu şifreler ve içeriğini yüklemek için gerekir. Yazma koruma şifresi, içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden bir açma şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açma şifresi korumasının varlığını kontrol edin ve tam bir sunum örneği oluşturmadan şifreyi doğrulayın.

**Bir uygulama açma şifresi olmadan meta verileri okuyabilir mi?**

Evet, ancak yalnızca belge‑özelliği şifrelemesi devre dışı bırakılmış bir sunumda mümkündür. Bu durumda uygulama, [Sunum Özelliklerini Yönetme](/slides/tr/nodejs-java/presentation-properties/) bölümünde açıklanan sadece belge‑özellikleri yükleme modunu kullanmalıdır.

**Şifre kontrol iş akışları hem PPT hem de PPTX’i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.