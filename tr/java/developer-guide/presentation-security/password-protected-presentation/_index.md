---
title: Java'da Şifreyle Güvenli Sunumlar
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/java/password-protected-presentation/
keywords:
- PowerPoint'ı kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunumun kilidini aç
- PowerPoint'ı koru
- sunumu koru
- şifre ayarla
- şifre ekle
- PowerPoint'ı şifrele
- sunumu şifrele
- PowerPoint'ı şifresini çöz
- sunumun şifresini çöz
- yazma koruması
- PowerPoint güvenliği
- sunum güvenliği
- şifreyi kaldır
- korumayı kaldır
- şifrelemeyi kaldır
- şifreyi devre dışı bırak
- korumayı devre dışı bırak
- yazma korumasını kaldır
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile şifreyle korunan PowerPoint ve OpenDocument sunumlarını kolaylıkla nasıl kilitleyip açacağınızı öğrenin. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarladığınız anlamına gelir. Bu kısıtlamaları kaldırmak için şifre girilmelidir. Şifreyle korunan bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bu kısıtlamaları bir sunumda uygulamak için bir şifre belirleyebilirsiniz:

- **Değişiklik**

Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların şifreyi girmediği sürece sunumdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını engeller.  

Ancak, şifre olmadan da bir kullanıcı belgenize erişebilir ve açabilir. Bu yalnızca okuma modunda, kullanıcı sunumunuzdaki içeriği—hiperlinkler, animasyonlar, efektler ve diğer öğeler dahil—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.

- **Açma**

Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların şifreyi sağlamadığı sürece sunumun içeriğini bile görüntülemelerini engeller.

Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller—eğer bir kişi sunumu açamazsa, onu değiştiremez veya değişiklik yapamaz.

**Not:** Bir sunumu açılmasını engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Aspose.Slides'ta Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumlarda şifre koruması kullanarak değişiklikleri önlemek için aşağıdaki yolları sunar:

- Sunumu şifrelemek
- Sunuma yazma koruması ayarlamak

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri aşağıdaki şekilde gerçekleştirmenizi sağlar:

- Sunumu şifre çözmek; şifreli bir sunumu açmak
- Şifrelemeyi kaldırmak; şifre korumasını devre dışı bırakmak
- Sunumdan yazma korumasını kaldırmak
- Şifreli bir sunumun özelliklerini almak
- Bir sunumun şifreli olup olmadığını kontrol etmek
- Bir sunumun şifreyle korunup korunmadığını kontrol etmek.

## **Bir Sunumu Şifreyle Koru**

Bir şifre belirleyerek bir sunumu şifreleyebilirsiniz. Ardından, kilitli sunumu değiştirmek için kullanıcı şifreyi sağlamalıdır.

Bir sunumu şifrelemek veya şifreyle korumak için, sunuma bir şifre ayarlamak adına encrypt yöntemini ([IProtectionManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager)) kullanmanız gerekir. Şifreyi encrypt yöntemine geçirirsiniz ve ardından save yöntemiyle şifrelenmiş sunumu kaydedersiniz.

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sunuma Yazma Koruması Ayarla**

Sunuma “Değiştirmeyin” ibaresi ekleyebilirsiniz. Böylece, kullanıcılara sunumda değişiklik yapmamalarını söylemiş olursunuz.  

**Not:** Yazma koruma işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten isterlerse—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla sunum oluşturmak zorundadır.

Yazma koruması ayarlamak için [setWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) yöntemini kullanmanız gerekir. Bu örnek kod, bir sunuma yazma koruması nasıl ayarlanacağını gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Şifreli Bir Sunumu Yükle**

Aspose.Slides, bir şifreyi vererek şifreli bir dosyayı yüklemenizi sağlar. Bir sunumu şifre çözmek için, parametresiz [removeEncryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#removeEncryption--) yöntemini çağırmanız gerekir. Ardından sunumu yüklemek için doğru şifreyi girmeniz istenir.

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // şifre çözülmüş sunumla çalış
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sunumdan Şifrelemeyi Kaldır**

Bir sunumdaki şifreleme ya da şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir.

Şifrelemeyi veya şifre korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#removeEncryption--) yöntemini çağırmanız gerekir. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sunumdan Yazma Korumasını Kaldır**

Aspose.Slides'i kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar istedikleri gibi değiştirebilir ve bu işlemleri yaparken herhangi bir uyarı görmezler.

Sunumdan yazma korumasını [removeWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) yöntemiyle kaldırabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Şifreli Bir Sunumun Özelliklerini Al**

Genellikle, kullanıcılar şifreli veya şifreyle korunan bir sunumun belge özelliklerini almada zorluk yaşar. Ancak, Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların özelliklerine erişebilme yeteneğini koruyan bir mekanizma sunar.

**Not:** Varsayılan olarak, Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifreyle korunur. Şifreleme sonrasında belge özelliklerine erişilebilir olmasını istiyorsanız, Aspose.Slides tam olarak bunu yapmanıza izin verir.

Kullanıcıların şifreli bir sunumun özelliklerine erişme yeteneğini korumasını istiyorsanız, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) yöntemine `false` parametresini geçin. Bu örnek kod, kullanıcıların belge özelliklerine erişimini sağlarken bir sunumu nasıl şifreleyeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Şifreli Bir Sunumdan Yalnızca Belge Özelliklerini Yükle**

Şifreli bir sunumun meta verilerini slaytlarını veya diğer içeriğini yüklemeden incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) nesnesi oluşturun ve [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) yöntemine `true` geçin. Bu modda, Aspose.Slides şifreyi göz ardı eder ve yalnızca herkese açık olan belge özelliklerini yükler.

Aşağıdaki kod örneği, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDocumentProperties--) aracılığıyla yerleşik ve özel belge özelliklerini okur:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Yerleşik belge özelliklerini oku.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Özel belge özelliklerini oku.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Bu iş akışı, sunum şifrelenirken belge özelliklerinin şifrelenmemiş (herkese açık) bırakıldığı durumlarda çalışır. Belge özellikleri şifrelenmişse, `loadOptions.setOnlyLoadDocumentProperties`'e `true` geçmek bir istisna oluşturur çünkü bu modda şifre göz ardı edilir. Şifreli belge özelliklerine erişmek veya slaytları ve diğer içeriği dahil olmak üzere tam bir sunumu yüklemek için doğru şifreyi [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) aracılığıyla sağlayın.

## **Bir Sunumun Şifreyle Korunup Korunmadığını Kontrol Et**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol edip doğrulamak isteyebilirsiniz. Böylece, şifreli bir sunum şifresi olmadan yüklendiğinde ortaya çıkan hataları ve benzeri sorunları önlersiniz.

Bu Java kodu, bir sunumun şifreyle korunup korunmadığını (sunumu kendisini yüklemeden) nasıl inceleyeceğinizi gösterir:

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Bir Sunumun Şifreli Olup Olmadığını Kontrol Et**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum şifreli ise `true`, değilse `false` dönen [isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#isEncrypted--) özelliğini kullanabilirsiniz. 

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumun Yazma Korumasına Sahip Olup Olmadığını Kontrol Et**

Aspose.Slides, bir sunumun yazma korumasına sahip olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum yazma korumalı ise `true`, değilse `false` dönen [isWriteProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#isWriteProtected--) özelliğini kullanabilirsiniz. 

Bu örnek kod, bir sunumun yazma korumasına sahip olup olmadığını nasıl kontrol edeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Belirli Bir Şifrenin Kullanıldığını Doğrula veya Onayla**

Belirli bir şifrenin bir sunum belgesini korumak için kullanıldığını kontrol etmek ve onaylamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanızı sağlar. 

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass" ile eşleşip eşleşmediğini kontrol et
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Belirtilen şifreyle şifrelenmişse `true`, aksi takdirde `false` döner.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil modern şifreleme yöntemlerini destekler ve sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış bir şifre girilirse ne olur?**

Yanlış şifre kullanılırsa bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifreyle korunan sunumlarla çalışırken performans açısından bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda, bu performans etkisi minimaldir ve sunum görevlerinizin genel işleme süresini önemli ölçüde etkilemez.