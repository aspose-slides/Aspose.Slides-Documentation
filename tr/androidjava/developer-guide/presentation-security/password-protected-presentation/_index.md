---
title: Android'de Sunumları Şifreyle Koruma
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/androidjava/password-protected-presentation/
keywords:
- şifrelenmiş sunum
- açılış şifresi
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum şifresini doğrulama
- sunum şifresini kontrol et
- şifreli sunumu aç
- şifrelemeyi kaldır
- PowerPoint
- PPT
- PPTX
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ı Java aracılığıyla kullanarak şifrelenmiş PowerPoint PPT ve PPTX sunumlarını şifrele, algıla, doğrula, aç ve şifresini çöz."
---
## **Genel Bakış**

Açılış şifresi bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru şifre gereklidir; bu koruma gizliliği sağlar.

Açılış şifresi, yazma koruma şifresinden farklıdır. Yazma koruması, içeriği şifrelemez ve sunumun yüklenmesini engellemez; yalnızca değişikliği kısıtlar. Sunumları değiştirmek için şifreleri yönetmek amacıyla [Sunumu Yazma Koruması](/slides/tr/androidjava/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları PPT ve PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu her iki formatı da kullanır.

## **Bir Açılış Şifresiyle Sunumu Şifreleme**

[Açılış şifresi atamak için IProtectionManager.encrypt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) metodunu kullanın. Ardından şifreli sunumu kaydetmek için [IPresentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metodunu çağırın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Şifreli Sunumu Yükleme**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metoduna açılış şifresini ayarlayın ve dosyayı yüklerken seçenekleri [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) nesnesine geçirin. Açılış şifresi gerekli olduğunda fakat verilen şifre eksik ya da hatalıysa yükleme başarısız olur.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Şifre çözülmüş sunumla çalış.
} finally {
    presentation.dispose();
}
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Sunumu açılış şifresiyle yükleyin, [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) metodunu çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra şifre gerektirmeden yüklenebilir.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Yüklemeden Önce Açılış Şifresini Doğrulama**

Tam bir sunum örneği oluşturmadan [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/) elde etmek için [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metodunu kullanın. Şifre talep etmeden ya da doğrulamadan önce [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) özelliğini kontrol edin. Koruma mevcutsa, verilen değeri [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açılış şifresini doğrular, doğrulanan değeri [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metoduna geçirir ve ardından tam sunumu yükler:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Akış İş Akışı**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) metodunun akış aşırı yüklemesi aynı iş akışını sunar. Tam sunumu o akıştan yüklemeden önce, arabelleklenebilir bir akışın konumunu sıfırlayın.

Aşağıdaki örnek bir PPT dosyası kullanır:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword Dönüş Değerleri**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) yalnızca sunumda bir açılış şifresi bulunuyorsa ve verilen şifre doğruysa `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Şifre yanlıştır.
- Sunumun bir açılış şifresi yoktur.
- Sağlanan şifre `null` ya da boştur.

Davranış PPT ve PPTX sunumları için aynıdır.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru şifreyle bir sunum yüklendikten sonra, kaynağın şifreli olduğunu doğrulamak için [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) özelliğine bakın. Yüklemeden önce açılış şifresi korumasını tespit etmek için yukarıda gösterildiği gibi `IPresentationInfo.isPasswordProtected` kullanın.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Güvenlik Önerileri**

{{% alert color="warning" title="Güvenlik" %}}
Açılış şifrelerini loglamayın veya tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama denemelerinden kaçının, şifreleri yalnızca gerektiği kadar bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreleme**

1. Aspose.Slides Lock uygulamasını açın.
1. Sunumu seçin veya yükleyin.
1. Görünüm koruması için bir şifre girin.
1. İsteğe bağlı olarak düzenleme koruması için ayrı bir şifre girin.
1. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="Ayrıca Bakınız" %}}
- [Sunumu Yazma Koruması](/slides/tr/androidjava/write-protected-presentation/)
- [PowerPoint'ta Dijital İmza](/slides/tr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açılış şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açılış şifresi sunumu şifreler ve içeriğin yüklenmesi için gereklidir. Yazma koruma şifresi içeriği şifrelemez, yalnızca değişikliği kısıtlar.

**Tüm slaytları yüklemeden bir açılış şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açılış şifresi korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan şifreyi doğrulayın.

**Şifre doğrulama iş akışları hem PPT hem de PPTX'i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre algılama ve doğrulama, PPT ve PPTX sunumları için aynı şekilde davranır.