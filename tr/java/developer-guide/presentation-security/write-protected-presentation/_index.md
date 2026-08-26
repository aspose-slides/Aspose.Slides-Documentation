---
title: Java'da Yazma Koruması ile Sunumları Koruma
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/java/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint'i yazma korumalı
- değiştirme şifresi
- sunum düzenlemesini kısıtla
- yazma korumasını kaldır
- değiştirme şifresini doğrula
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruması şifrelerini ayarlayın, tespit edin, doğrulayın ve kaldırın."
---
## **Giriş**

Yazma koruması şifresi bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar, şifre olmadan yazma korumalı bir sunumu yükleyebilir ve görüntüleyebilir. Uygulamaya bağlı olarak, içeriği düzenleyebilir ve farklı bir adla kaydedebilirler, bu nedenle yazma koruması gizlilik mekanizması olarak değerlendirilmemelidir.

Açma şifresi farklı bir amaç hizmet eder: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma şifresini doğrulamak için [Password-Protect Presentations](/slides/tr/java/password-protected-presentation/) bölümüne bakın.

Bu makaledeki çalışma akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kaydetme biçimini kullanın.

## **Sunuma Yazma Koruması Ayarlama**

Bir sunumu değiştirmek için şifre atamak amacıyla [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) yöntemini kullanın. Sunumu kaydetmek koruma ayarını kalıcı hâle getirir.

Aşağıdaki örnek bir PPTX sunumuna yazma koruması ekler:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Yazma Koruması Olan Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediği için sunumu yüklemek için şifre gerekmez. Şifre yalnızca korumalı sunumu değiştirme yetkisini doğrularken relevandır.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Yazma koruması şifresini [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metoduna geçirmeyin. Bu metod şifreli içerik için bir açma şifresi alır. Bir sunumda her iki koruma türü de varsa, onu yüklemek için açma şifresini sağlayın ve yazma koruması şifresini ayrı olarak işleyin.

## **Sunumdan Yazma Korumasını Kaldırma**

[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) yöntemini kullanarak değişiklik kısıtlamasını kaldırın, ardından sunumu kaydedin.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Bir dosyayı tam bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği oluşturmadan incelemek için [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metodunu çağırın ve [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) özelliğine bakın. Metot [NullableBool](https://reference.aspose.com/slides/tr/java/com.aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool.True` döndürür.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) metodunun akış aşırı yüklemesi, akış olarak sağlanan bir sunum için aynı bilgileri sunar.

## **Yazma Koruma Şifresini Doğrulama**

Tam bir sunumu yüklemeden bir değişiklik şifresini doğrulamak için [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) metodunu kullanın. Uygulamanın şifre talep etmesi veya doğrulaması yalnızca yazma koruması mevcut olduğunda gerçekleşsin diye önce [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) kontrol edin.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) sadece yazma koruma şifresini doğrular. Açma şifresini doğrulamaz ve şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Buna karşılık, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) sadece açma şifresini doğrular. Tam bir sunum zaten yüklendiyse, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) koruma yöneticisi aracılığıyla eşdeğer bir yazma koruma kontrolü sağlar.

Üretim uygulamalarında şifreleri loglamayın veya tanı mesajlarına dahil etmeyin. Gereksiz tekrar doğrulama denemelerinden kaçının ve şifreleri bellekte yalnızca ihtiyaç duyulduğu süre kadar tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Password-Protect Presentations](/slides/tr/java/password-protected-presentation/)
- [Read-Only Presentations](/slides/tr/java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değişikliği kısıtlar ancak sunum içeriğini yükleme ve görüntüleme için erişilebilir bırakır.

**Yazma koruma şifresi bir sunumu açmak için gerekli mi?**

Hayır. Şifreli sunum içeriğini yüklemek için yalnızca bir açma şifresi gerekir.

**Bir sunum hem açma şifresi hem de yazma koruma şifresi taşıyabilir mi?**

Evet. Şifreli sunumu açmak için yükleme seçenekleri aracılığıyla açma şifresini sağlayın ve değişiklik yetkisi gerektiğinde yazma koruma şifresini ayrı olarak doğrulayın.