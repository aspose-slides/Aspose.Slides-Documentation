---
title: Java'da Sunumları Şifreyle Koruma
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/java/password-protected-presentation/
keywords:
- şifre korumalı sunum
- açma şifresi
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum şifresini doğrulama
- sunum şifresini kontrol et
- şifreli sunumu açma
- şifrelemeyi kaldırma
- PowerPoint
- PPT
- PPTX
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da şifre korumalı PowerPoint PPT ve PPTX sunumlarını şifrele, tespit et, doğrula, aç ve şifresini çöz."
---
## **Genel Bakış**

Açma şifresi bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru şifre gereklidir; bu koruma gizliliği sağlar.

Açma şifresi, yazma koruma şifresinden farklıdır. Yazma koruması değişikliği kısıtlar ancak içeriği şifrelemez ya da sunumun yüklenmesini engellemez. Sunumları değiştirmek için şifreleri yönetmek üzere, [Write-Protect Presentations](/slides/tr/java/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları PPT ve PPTX sunumları için geçerlidir. Örneklerde, dosya tabanlı ve akış tabanlı davranışların önemli olduğu her iki biçim de kullanılmıştır.

## **Açma Şifresi ile Sunumu Şifreleme**

Açma şifresi atamak için [IProtectionManager.encrypt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) yöntemini kullanın. Ardından şifreli sunumu kalıcı hâle getirmek için [IPresentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) yöntemini kullanın.

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

[ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) özelliğine açma şifresini atayın ve dosyayı yüklerken seçenekleri [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfına geçirin. Açma şifresi gerekli ancak verilen şifre eksik ya da hatalı ise yükleme başarısız olur.

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

## **Sunumdan Şifrelemeyi Kaldırma**

Sunumu açma şifresi ile yükleyin, [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra şifre olmadan yüklenebilir.

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

## **Yüklemeden Önce Açma Şifresini Doğrulama**

Tam bir sunum örneği oluşturmadan [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/) elde etmek için [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) yöntemini kullanın. Şifre isteği veya doğrulama yapmadan önce [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) özelliğini kontrol edin. Koruma mevcutsa, verilen değeri [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açma şifresini doğrular, doğrulanan değeri [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) yöntemine geçirir ve ardından tam sunumu yükler:

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) yönteminin akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu o akıştan yüklemeden önce, aranabilir bir akışın konumunu sıfırlayın.

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

### **checkPassword Geri Dönüş Değerleri**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) yalnızca sunumun bir açma şifresi olduğu ve verilen şifrenin doğru olduğu durumlarda `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Şifre yanlıştır.
- Sunumun bir açma şifresi yoktur.
- Verilen şifre `null` ya da boştur.

Davranış PPT ve PPTX sunumları için aynıdır.

## **Yüklenmiş Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Doğru şifre ile bir sunumu yükledikten sonra, kaynağın şifreli olduğunu onaylamak için [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) özelliğine bakın. Yüklemeden önce açma şifresi korumasını tespit etmek için yukarıda gösterildiği gibi `IPresentationInfo.isPasswordProtected` kullanın.

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

{{% alert color="warning" title="Security" %}}
Açma şifrelerini günlük kaydına almaktan veya tanılayıcı mesajlarda bulundurmaktan kaçının. Gereksiz tekrar doğrulama girişimlerinden kaçının, şifreleri yalnızca gerektiği sürece bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreleme**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
1. Sunumu seçin ya da yükleyin.
1. Görüntüleme koruması için bir şifre girin.
1. İsteğe bağlı olarak düzenleme koruması için ayrı bir şifre girin.
1. Korumayı uygulayın ve oluşan dosyayı indirin.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/tr/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açma şifresi sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma şifresi, içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden bir açma şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açma şifresi korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan şifreyi doğrulayın.

**Şifre kontrol iş akışları PPT ve PPTX için destekleniyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre algılama ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.