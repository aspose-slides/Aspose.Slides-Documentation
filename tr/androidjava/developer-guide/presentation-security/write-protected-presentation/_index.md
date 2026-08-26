---
title: Android'de Sunumları Yazma Koruması ile Koruma
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/androidjava/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint yazma koruması
- değiştirme parolası
- sunum düzenlemesini kısıtlama
- yazma korumasını kaldırma
- değiştirme parolasını doğrulama
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruma parolalarını ayarlama, algılama, doğrulama ve kaldırma."
---
## **Giriş**

Yazma koruması parolası bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar, yazma korumalı bir sunumu parolasız olarak yükleyebilir ve görüntüleyebilir. Uygulamaya bağlı olarak içeriği düzenleyebilir ve farklı bir adla kaydedebilirler, bu nedenle yazma koruması bir gizlilik mekanizması olarak değerlendirilmemelidir.

Açma parolası farklı bir amaç taşır: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma parolasını doğrulamak için bkz. [Password-Protect Presentations](/slides/tr/androidjava/password-protected-presentation/).

Bu makaledeki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kaydetme biçimini kullanın.

## **Sunumda Yazma Koruması Ayarlama**

[IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) kullanarak bir sunumu değiştirmek için parola atayın. Sunumu kaydetmek koruma ayarını kalıcı hâle getirir.

Aşağıdaki örnek bir PPTX sunumunda yazma koruması ayarlar:

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

## **Yazma Koruması Olan Bir Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediği için sunumu yüklemek için parola gerekmez. Parola yalnızca korumalı sunumu değiştirme yetkisini doğrularken ilgilidir.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Yazma koruması parolasını [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metoduna iletmeyin. Bu yöntem şifreli içerik için bir açma parolası kabul eder. Bir sunum her iki koruma türüne de sahipse, şifreli sunumu açmak için açma parolasını sağlayın ve yazma koruması parolasını ayrı olarak ele alın.

## **Bir Sunumdan Yazma Korumasını Kaldırma**

[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) kullanarak değişiklik kısıtlamasını kaldırın, ardından sunumu kaydedin.

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

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Tam bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneği oluşturmadan bir dosyayı incelemek için [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metodunu çağırın ve [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) özelliğini kontrol edin. Metot [NullableBool](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool.True` döndürür.

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) metodunun akış (stream) aşırı yüklemesi, akış olarak sağlanan bir sunum için aynı bilgileri verir.

## **Yazma Koruma Parolasını Doğrulama**

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) kullanarak tam sunumu yüklemeden bir değiştirme parolasını doğrulayın. Uygulamanın yalnızca yazma koruması mevcut olduğunda parola isteyip doğrulaması için önce [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) kontrol edilmelidir.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) yalnızca yazma koruma parolasını doğrular. Açma parolasını doğrulamaz ve şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Bunun tersine, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) yalnızca bir açma parolasını doğrular. Eğer tam bir sunum zaten yüklendiyse, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) koruma yöneticisi üzerinden eşdeğer bir yazma koruma denetimi sağlar.

Üretim uygulamalarında parolaları günlüğe kaydetmeyin ve tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama denemelerinden kaçının ve parolaları yalnızca gerektiği sürece bellekte tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Password-Protect Presentations](/slides/tr/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/tr/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değiştirilmesini kısıtlar ancak sunum içeriği yükleme ve görüntüleme için kullanılabilir durumda bırakır.

**Yazma koruması parolası bir sunumu açmak için gerekli mi?**

Hayır. Şifreli sunum içeriğini yüklemek için yalnızca açma parolası gerekir.

**Bir sunum hem açma parolası hem de yazma koruması parolası içerebilir mi?**

Evet. Şifreli sunumu açmak için yükleme seçenekleri aracılığıyla açma parolasını sağlayın ve değiştirme yetkisi gerektiğinde yazma koruması parolasını ayrı olarak doğrulayın.