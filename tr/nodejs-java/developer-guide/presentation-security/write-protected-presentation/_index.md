---
title: JavaScript'te Sunumları Yazma Koruması
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/nodejs-java/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint'te yazma koruması
- değiştirme parolası
- sunum düzenlemesini kısıtlama
- yazma korumasını kaldırma
- değiştirme parolasını doğrulama
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruması parolalarını ayarlama, tespit etme, doğrulama ve kaldırma."
---
## **Giriş**

Yazma koruması parolası, bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar, yazma korumalı bir sunumu parolası olmadan yükleyebilir ve görüntüleyebilir. Uygulamaya bağlı olarak, içeriği düzenleyip farklı bir adla kaydedebilirler, bu nedenle yazma koruması gizlilik mekanizması olarak değerlendirilmemelidir.

Açma parolası farklı bir amaç sağlar: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma parolasını doğrulamak için, [Sunumları Parola ile Koruma](/slides/tr/nodejs-java/password-protected-presentation/) sayfasına bakın.

Bu makaledeki iş akışları PPT ve PPTX sunumları için geçerlidir. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kayıt formatını kullanın.

## **Bir Sunuma Yazma Koruması Ayarlama**

Bir sunumu değiştirmek için parola atamak üzere [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) yöntemini kullanın. Sunumu kaydetmek, koruma ayarını kalıcı hale getirir.

Aşağıdaki örnek, bir PPTX sunumuna yazma koruması ekler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Yazma Koruması Olan Bir Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediği için, sunumu yüklemek için parola gerekmez. Parola, yalnızca korumalı sunumu değiştirme yetkisini doğrularken ilgilidir.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

[LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setPassword) yöntemine yazma koruması parolası geçirmeyin. Bu yöntem, şifreli içerik için bir açma parolası kabul eder. Bir sunum her iki koruma türüne de sahipse, açma parolasını vererek sunumu yükleyin ve yazma koruması parolasını ayrı olarak işleyin.

## **Bir Sunumdan Yazma Korumasını Kaldırma**

Değiştirme kısıtlamasını kaldırmak için [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) yöntemini kullanın, ardından sunumu kaydedin.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Bir dosyayı tam bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturmadan incelemek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) yöntemini çağırın ve [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) özelliğini kontrol edin. Metot, [NullableBool](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool.True` döndürür.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Akış tabanlı [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) yöntemi, Node.js okunabilir akışı olarak sağlanan bir sunum için aynı bilgileri sunar.

## **Yazma Koruması Parolasını Doğrulama**

Tam sunumu yüklemeden bir değiştirme parolasını doğrulamak için [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) yöntemini kullanın. Uygulamanın sadece yazma koruması mevcut olduğunda parola isteyip doğrulaması için önce [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) kontrol edin.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) yalnızca yazma koruması parolasını doğrular. Bir açma parolasını doğrulamaz veya şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Bunun tersine, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#checkPassword) sadece bir açma parolasını doğrular. Eğer tam bir sunum zaten yüklendiyse, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) koruma yöneticisi üzerinden eşdeğer bir yazma koruması kontrolü sağlar.

Üretim ortamındaki uygulamalarda, parolaları loglamayın veya tanı mesajlarına eklemeyin. Gereksiz tekrarlanan doğrulama denemelerinden kaçının ve parolaları yalnızca gerekli olduğu süre boyunca bellekte tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Sunumları Parola ile Koruma](/slides/tr/nodejs-java/password-protected-presentation/)
- [Salt Okunur Sunumlar](/slides/tr/nodejs-java/read-only-presentation/)
- [PowerPoint'te Dijital İmza](/slides/tr/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değiştirmeyi kısıtlar ancak sunum içeriğini yükleme ve görüntüleme için kullanılabilir tutar.

**Sunumu açmak için yazma koruması parolası gerekli mi?**

Hayır. Şifreli sunum içeriğini yüklemek için yalnızca bir açma parolası gereklidir.

**Bir sunum hem açma parolası hem de yazma koruması parolası içerebilir mi?**

Evet. Şifreli sunumu açmak için yükleme seçenekleri aracılığıyla açma parolasını sağlayın ve değiştirme yetkisi gerektiğinde yazma koruması parolasını ayrı olarak doğrulayın.