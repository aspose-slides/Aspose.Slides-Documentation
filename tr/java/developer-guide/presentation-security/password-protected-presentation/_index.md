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
description: "Java'da Aspose.Slides ile şifre korumalı PowerPoint PPT ve PPTX sunumlarını şifreleyin, tespit edin, doğrulayın, açın ve şifrelerini çözün."
---
## **Genel Bakış**

Açma şifresi bir sunumu şifreler. Doğru şifre, sunum içeriğini yüklemek ve görüntülemek için gereklidir, bu da korumanın gizliliğini sağlar.

Açma şifresi, yazma koruma şifresinden farklıdır. Yazma koruması değişikliği kısıtlar ancak içeriği şifrelemez ve sunumun yüklenmesini engellemez. Sunumları değiştirmek için şifreleri yönetmek üzere [Write-Protect Presentations](/slides/tr/java/write-protected-presentation/) sayfasına bakın.

Aşağıdaki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu durumlarda her iki formatı da kullanır.

## **Açma Şifresi ile Sunumu Şifreleme**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) metodunu kullanarak bir açma şifresi atayın. Ardından şifrelenmiş sunumu kalıcı hâle getirmek için [IPresentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metodunu kullanın.

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

## **Belge Özelliklerini Genel Tutma**

Varsayılan olarak, Aspose.Slides belge özelliklerini sunum şifrelemesine dahil eder. [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) yöntemi bu davranışı slayt içeriği şifrelemesinden bağımsız olarak kontrol eder. Bir indeksleme, sınıflandırma, arama veya belge yönetim sistemi açma şifresi olmadan üst verileri okuması gerektiğinde, [IProtectionManager.encrypt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) metodunu çağırmadan önce `false` geçin.

Aşağıdaki örnek, gömülü belge özellikleri genel bırakılarak şifrelenmiş bir PPTX sunumu oluşturur:

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

`false` değerini [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metoduna geçirmek, slaytları, ana slaytları, düzenleri, şekilleri, medyayı veya diğer sunum içeriğini genel hâle getirmez. Yalnızca belge özelliklerini etkiler. Şifreli içeriği yüklemeden bu özellikleri okumak için [Manage Presentation Properties](/slides/tr/java/presentation-properties/) sayfasına bakın.

## **Şifreli Sunumu Yükleme**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) ayarını açma şifresi olarak belirleyin ve dosya yüklenirken bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) metoduna iletin. Açma şifresi gerekli olduğu halde sağlanan şifre eksik veya yanlışsa yükleme başarısız olur.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Şifre çözülen sunum üzerinde çalış.
} finally {
    presentation.dispose();
}
```

## **Sunumdan Şifreyi Kaldırma**

Sunumu açma şifresiyle yükleyin, [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) metodunu çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra şifre olmadan yüklenebilir.

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metodunu kullanarak tam bir sunum örneği oluşturmadan [IPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/) alın. Şifre talep etmeden veya doğrulamadan önce [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) kontrol edin. Koruma mevcutsa, sağlanan değeri [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açma şifresini doğrular, doğrulanan değeri [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metoduna aktarır ve ardından tam sunumu yükler:

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) metodunun akış aşırı yüklemesi aynı iş akışını sunar. O akıştan tam sunumu yüklemeden önce, aranabilir bir akışın konumunu sıfırlayın.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) yalnızca sunumda açma şifresi olduğu ve sağlanan şifre doğru olduğunda `true` döner. Aşağıdaki durumların her birinde `false` döner:

- Şifre yanlıştır.
- Sunumda açma şifresi yoktur.
- Sağlanan şifre `null` veya boştur  
Davranış PPT ve PPTX sunumları için aynı şekildedir.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru şifreyle bir sunumu yükledikten sonra, kaynak sunumun şifrelenip şifrelenmediğini doğrulamak için [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) yöntemini inceleyin. Yüklemeden önce açma şifresi korumasını tespit etmek için yukarıda gösterildiği gibi `IPresentationInfo.isPasswordProtected` kullanın.

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
Açma şifrelerini günlük dosyalarına kaydetmeyin ya da tanılayıcı mesajlarda kullanmayın. Gereksiz tekrar doğrulama denemelerinden kaçının, şifreleri yalnızca gerektiği sürece bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.

Genel belge özellikleri, sunum içeriği şifreli olsa da yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ifşa edebilir. Hassas üst verileri sunumla birlikte şifreleyin. Özelliklerin genel bırakılması, yalnızca sistemlerin dosyayı açma şifresi olmadan indekslemesi, sınıflandırması, araması veya yönetmesi gerektiğinde alınacak açık bir karar olmalıdır.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreleme**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.  
1. Sunumu seçin veya yükleyin.  
1. Görüntüleme koruması için bir şifre girin.  
1. İsteğe bağlı olarak düzenleme koruması için ayrı bir şifre girin.  
1. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="Ayrıca" %}}
- [Write-Protect Presentations](/slides/tr/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açma şifresi sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma şifresi ise içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden açma şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açma şifresi korumasının varlığını kontrol edin ve tam bir sunum örneği oluşturmadan önce şifreyi doğrulayın.

**Bir uygulama açma şifresi olmadan üst verileri okuyabilir mi?**

Evet, ancak yalnızca sunum belge‑özelliği şifrelemesi devre dışı bırakılarak şifrelenmişse mümkündür. Bu durumda uygulama, [Manage Presentation Properties](/slides/tr/java/presentation-properties/) bölümünde açıklanan yalnızca belge‑özelliklerini yükleme modunu kullanmalıdır.

**Şifre kontrol iş akışları hem PPT hem PPTX’i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.