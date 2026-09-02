---
title: JavaScript'te Sunumları Parola ile Koruma
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/nodejs-java/password-protected-presentation/
keywords:
- parola korumalı sunum
- açılış parolası
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum parolasını doğrulama
- sunum parolasını kontrol etme
- şifreli sunumu açma
- şifrelemeyi kaldırma
- PowerPoint
- PPT
- PPTX
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile JavaScript'te parola korumalı PowerPoint PPT ve PPTX sunumlarını şifreleme, tespit etme, doğrulama, açma ve şifre çözme."
---
## **Genel Bakış**

Açılış şifresi bir sunumu şifreler. Doğru şifre, sunum içeriğini yüklemek ve görüntülemek için gereklidir; bu koruma gizlilik sağlar.

Açılış şifresi, yazma koruma şifresinden farklıdır. Yazma koruması değişiklik yapmayı kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için şifreleri yönetmek amacıyla, [Write-Protect Presentations](/slides/tr/nodejs-java/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları hem PPT hem de PPTX sunumlarına uygulanır. Örnekler, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu her iki formatı da kullanır.

## **Açılış Şifresi ile Sunumu Şifreleme**

[ProtectionManager.encrypt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#encrypt) metodunu kullanarak bir açılış şifresi atayın. Ardından şifrelenmiş sunumu kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metodunu kullanın.

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

## **Şifreli Sunumu Yükleme**

[LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) metodunu açılış şifresi olarak ayarlayın ve dosyayı yüklerken seçenekleri [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) içine geçirin. Açılış şifresi gerekli olduğunda ancak sağlanan şifre eksik ya da yanlış olduğunda yükleme başarısız olur.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Şifrelenmiş sunumla çalış.
} finally {
    presentation.dispose();
}
```

## **Sunumdan Şifrelemeyi Kaldırma**

Sunumu açılış şifresi ile yükleyin, [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) metodunu çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra şifre olmadan yüklenebilir.

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

## **Yüklemeden Önce Açılış Şifresini Doğrulama**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) metodunu kullanarak tam bir sunum örneği oluşturmadan [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) alın. Şifre talep etmeden veya doğrulamadan önce [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) kontrol edin. Koruma mevcut olduğunda, sağlanan değeri [PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#checkPassword) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açılış şifresini doğrular, doğrulanan değeri [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) metoduna geçirir ve ardından tam sunumu yükler:

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

[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) metodunu kullanarak bir Node.js okunabilir akışı inceleyin. İnceleme akışı tüketildikten sonra, tam sunumu [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) ile yüklemeden önce yeni bir akış oluşturun.

Aşağıdaki örnek bir PPT dosyası kullanır:

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#checkPassword) yalnızca sunumun bir açılış şifresi olduğu ve sağlanan şifrenin doğru olduğu durumlarda `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Şifre yanlıştır.
- Sunumun bir açılış şifresi yoktur.
- Sağlanan şifre `null` veya boş.

Davranış, PPT ve PPTX sunumları için aynıdır.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru şifre ile bir sunumu yükledikten sonra, kaynak sunumun şifreli olduğunu doğrulamak için [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) kontrol edin. Yüklemeden önce açılış şifresi korumasını tespit etmek için yukarıda gösterildiği gibi [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) metodunu kullanın.

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

{{% alert color="warning" title="Güvenlik" %}}
Açılış şifrelerini günlüğe kaydetmeyin ve tanı mesajlarına eklemeyin. Gereksiz tekrarlanan doğrulama girişimlerinden kaçının, şifreleri yalnızca gerektiği süre boyunca bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreleme**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
2. Sunumu seçin veya yükleyin.
3. Görünüm koruması için bir şifre girin.
4. İsteğe bağlı olarak düzenleme koruması için ayrı bir şifre girin.
5. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="Ayrıca Bakınız" %}}
- [Sunumları Yazma Koruması](/slides/tr/nodejs-java/write-protected-presentation/)
- [PowerPoint'ta Dijital İmza](/slides/tr/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açılış şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açılış şifresi sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma şifresi ise içeriği şifrelemeden değişiklik yapmayı kısıtlar.

**Tüm slaytları yüklemeden açılış şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açılış şifresi korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan önce şifreyi doğrulayın.

**Şifre kontrol iş akışları hem PPT hem de PPTX'i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.