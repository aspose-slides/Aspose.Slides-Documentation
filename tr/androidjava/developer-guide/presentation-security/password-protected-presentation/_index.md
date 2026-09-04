---
title: Android'da Sunumları Parola ile Koruma
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/androidjava/password-protected-presentation/
keywords:
- parola korumalı sunum
- açılış parolası
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum parolasını doğrulama
- sunum parolasını kontrol et
- şifreli sunumu açma
- şifrelemeyi kaldırma
- PowerPoint
- PPT
- PPTX
- sunum
- Android
- Java
- Aspose.Slides
description: "Parola korumalı PowerPoint PPT ve PPTX sunumlarını Aspose.Slides for Android via Java ile şifreleyin, algılayın, doğrulayın, açın ve şifresini çözün."
---
## **Genel Bakış**

Açılış parolası bir sunumu şifreler. Doğru parola, sunum içeriğini yüklemek ve görüntülemek için gereklidir; bu koruma gizlilik sağlar.

Açılış parolası, bir yazma koruma parolasından farklıdır. Yazma koruması değişiklik yapmayı kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için parolaları yönetmek amacıyla, [Write-Protect Presentations](/slides/tr/androidjava/write-protected-presentation/) sayfasına bakın.

Aşağıdaki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu durumlarda her iki formatı da kullanır.

## **Açılış Parolasıyla Bir Sunumu Şifreleme**

Açılış parolası atamak için [IProtectionManager.encrypt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) yöntemini kullanın. Ardından şifrelenmiş sunumu kalıcı hâle getirmek için [IPresentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) yöntemini kullanın.

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

## **Belge Özelliklerini Açık Tutun**

Varsayılan olarak, Aspose.Slides sunum şifrelemesine belge özelliklerini de dahil eder. [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) yöntemi, bu davranışı slayt içeriği şifrelemesinden bağımsız olarak kontrol eder. Bir indeksleme, sınıflandırma, arama veya belge yönetim sistemi, açılış parolası olmadan meta verileri okuması gerektiğinde, [IProtectionManager.encrypt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) çağırmadan önce `false` gönderin.

Aşağıdaki örnek, yerleşik belge özelliklerini açık bırakarak şifrelenmiş bir PPTX sunumu oluşturur:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false` değerini [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) yöntemine geçirmeniz, slaytları, masterları, düzenleri, şekilleri, medyayı veya diğer sunum içeriğini açık hâle getirmez. Bu sadece belge özelliklerini etkiler. Şifrelenmiş içeriği yüklemeden bu özellikleri okumak için [Manage Presentation Properties](/slides/tr/androidjava/presentation-properties/) sayfasına bakın.

## **Şifrelenmiş Bir Sunumu Yükleme**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) özelliğini açılış parolası olarak ayarlayın ve dosyayı yüklerken bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfına geçirin. Açılış parolası gerektiğinde ancak verilen parola eksik ya da hatalı olduğunda yükleme başarısız olur.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Şifre çözülmüş sunumla çalışın.
} finally {
    presentation.dispose();
}
```

## **Bir Sunumun Şifrelemesini Kaldırma**

Sunumu açılış parolasıyla yükleyin, [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra parola olmadan yüklenebilir.

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

## **Yüklemeden Önce Açılış Parolasını Doğrulama**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metodunu kullanarak tam bir sunum örneği oluşturmadan [IPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/) elde edin. Parola talep etmeden veya doğrulamadan önce [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) özelliğini kontrol edin. Koruma mevcutsa, verilen değeri [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açılış parolasını doğrular, doğrulanan değeri [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) yöntemine geçirir ve ardından tam sunumu yükler:

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) metodunun akış aşırı yüklemesi aynı iş akışını sunar. O akıştan tam sunumu yüklemeden önce, aranabilir bir akışın konumunu sıfırlayın.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) yalnızca sunumun bir açılış parolası olduğu ve verilen parolanın doğru olduğu durumda `true` döner. Aşağıdaki durumların her birinde `false` döner:

- Parola yanlıştır.
- Sunumun açılış parolası yoktur.
- Verilen parola `null` veya boştur.

Davranış PPT ve PPTX sunumları için aynıdır.

## **Yüklenen Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Doğru parola ile bir sunumu yükledikten sonra, kaynak sunumun şifrelenip şifrelenmediğini doğrulamak için [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) özelliğini inceleyin. Yüklemeden önce açılış parolası korumasını tespit etmek için, yukarıda gösterildiği gibi `IPresentationInfo.isPasswordProtected` kullanın.

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
Açılış parolalarını günlüğe kaydetmeyin veya tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının, parolaları yalnızca gerektiği süre boyunca bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.

Genel belge özellikleri, sunum içeriği şifreli olsa bile yazar adları, başlıklar, konu, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerler gibi bilgileri ortaya çıkarabilir. Hassas meta verileri sunumla birlikte şifreleyin. Özelliklerin genel bırakılması, yalnızca sistemlerin dosyayı açılış parolası olmadan indekslemesi, sınıflandırması, araması veya yönetmesi gerektiğinde alınacak açık bir karar olmalıdır.
{{% /alert %}}

## **Bir Sunumu Çevrimiçi Parola ile Koruma**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
1. Sunumu seçin veya yükleyin.
1. Görüntü koruması için bir parola girin.
1. İsteğe bağlı olarak düzenleme koruması için ayrı bir parola girin.
1. Korumanı uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="Ayrıca Bakınız" %}}
- [Write-Protect Presentations](/slides/tr/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açılış parolası ile yazma koruma parolası arasındaki fark nedir?**

Açılış parolası sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma parolası ise içeriği şifrelemeden değişiklik yapmayı kısıtlar.

**Tüm slaytları yüklemeden bir açılış parolasını doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açılış parolası korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan önce parolayı doğrulayın.

**Bir uygulama açılış parolası olmadan meta verileri okuyabilir mi?**

Evet, ancak sadece sunum belge özelliği şifrelemesi devre dışı bırakılarak şifrelenmişse. Bu durumda uygulama, [Manage Presentation Properties](/slides/tr/androidjava/presentation-properties/) bölümünde açıklanan sadece belge özelliklerini yükleme modunu kullanmalıdır.

**Parola kontrol iş akışları hem PPT hem de PPTX'i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı parola algılama ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.