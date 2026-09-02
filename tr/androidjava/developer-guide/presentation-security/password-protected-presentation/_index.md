---
title: Android'de Parolalarla Güvenli Sunumlar
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/androidjava/password-protected-presentation/
keywords:
- PowerPoint'i Kilitle
- Sunumu Kilitle
- PowerPoint'i Kilidini Aç
- Sunumu Kilidini Aç
- PowerPoint'i Koru
- Sunumu Koru
- Parola Ayarla
- Parola Ekle
- PowerPoint'i Şifrele
- Sunumu Şifrele
- PowerPoint'i Şifreyi Çöz
- Sunumu Şifreyi Çöz
- Yazma Koruması
- PowerPoint Güvenliği
- Sunum Güvenliği
- Parolayı Kaldır
- Koruma Kaldır
- Şifrelemeyi Kaldır
- Parolayı Devre Dışı Bırak
- Koruma Devre Dışı Bırak
- Yazma Korumasını Kaldır
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java üzerinden Android için Aspose.Slides ile parola korumalı PowerPoint ve OpenDocument sunumlarını zahmetsizce kilitleyin ve kilidini açın. Sunumlarınızı güvende tutun."
---
## **Giriş**

Bir sunumu parola ile koruduğunuzda, sunuma belirli kısıtlamalar getiren bir parola ayarlamış olursunuz. Kısıtlamaları kaldırmak için parola girilmelidir. Parola korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle bir sunuma bu kısıtlamaları uygulamak için bir parola belirleyebilirsiniz:

- **Değişiklik**

  Yalnızca belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kişiler sunumunuzu değiştirmesini, düzenlemesini veya kopyalamasını (parolayı sağlayıp sağlamadıklarına bakılmaksızın) engeller.  

  Ancak bu durumda, parola olmadan da bir kullanıcı belgeye erişip açabilir. Bu sadece‑okuma modunda kullanıcı içeriği, hiperlinkleri, animasyonları, efektleri ve diğer öğeleri görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.  

- **Açma**

  Yalnızca belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kişiler sunumunuzun içeriğini (parolayı sağlamadıkları sürece) görüntülemesini engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller: Sunum açılamadığında değişiklik yapılamaz.  

  **Not** bir sunumu açmayı engellemek için parola koruması uyguladığınızda, sunum dosyası şifrelenir.

## **Aspose.Slides'ta Sunumlar için Parola Koruması**
**Desteklenen biçimler**

Aspose.Slides, aşağıdaki biçimlerdeki sunumlar için parola koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX ve PPT – Microsoft PowerPoint Sunumu  
- ODP – OpenDocument Sunumu  
- OTP – OpenDocument Sunum Şablonu  

**Desteklenen işlemler**

Aspose.Slides, sunumlarda aşağıdaki şekillerde değişiklikleri önlemek için parola koruması kullanmanıza olanak tanır:

- Sunumu şifreleme  
- Sunuma yazma koruması ayarlama  

**Diğer işlemler**

Aspose.Slides, parola koruması ve şifreleme ile ilgili aşağıdaki görevleri yerine getirmenizi sağlar:

- Sunumu çözme; şifreli bir sunumu açma  
- Şifreyi kaldırma; parola korumasını devre dışı bırakma  
- Sunumdan yazma korumasını kaldırma  
- Şifreli bir sunumun özelliklerini alma  
- Sunumun şifreli olup olmadığını kontrol etme  
- Sunumun parola korumalı olup olmadığını kontrol etme.

## **Bir Sunumu Şifrele**

Bir sunumu parola belirleyerek şifreleyebilirsiniz. Kilitli sunumu değiştirmek isteyen bir kullanıcı parolayı girmek zorundadır.  

Bir sunumu şifrelemek veya parola koruması eklemek için, sunuma parola ayarlamak amacıyla [IProtectionManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager) üzerindeki `encrypt` yöntemini kullanmanız gerekir. Parolayı `encrypt` yöntemine geçirir ve ardından şifreli sunumu kaydetmek için `save` yöntemini kullanırsınız.

Bu örnek kod bir sunumu nasıl şifreleyeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunuma Yazma Koruması Ayarla**

Sunuma “Değiştirmeyin” işareti ekleyebilirsiniz. Bu sayede kullanıcılara sunumu değiştirmelerini istemediğinizi bildirebilirsiniz.  

**Not** yazma koruma işlemi sunumu şifrelemez. Bu nedenle kullanıcılar – gerçekten isterlerse – sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla yeni bir sunum oluşturmak zorundadırlar.  

Yazma koruması ayarlamak için [setWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) yöntemini kullanmanız gerekir. Bu örnek kod bir sunuma nasıl yazma koruması ekleyeceğinizi gösterir:

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

Aspose.Slides, şifreli bir dosyayı parolasını geçirerek yüklemenize izin verir. Bir sunumu çözmek için parametresiz olarak [removeEncryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) yöntemini çağırmalısınız. Ardından sunumu yüklemek için doğru parolayı girmeniz gerekir.

Bu örnek kod bir sunumu nasıl çözeceğinizi gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // çözülmüş sunumla çalış
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumdan Şifreyi Kaldır**

Bir sunumun şifreleme veya parola korumasını kaldırabilirsiniz. Bu sayede kullanıcılar sunuma kısıtlamasız erişebilir veya değiştirebilir.  

Şifreyi veya parola korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) yöntemini çağırmanız gerekir. Bu örnek kod bir sunumdan şifreyi nasıl kaldıracağınızı gösterir:

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

## **Bir Sunumdan Yazma Korumasını Kaldır**

Aspose.Slides ile bir sunum dosyasına uygulanan yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir ve böyle bir işlem yaparken uyarı almazlar.  

Yazma korumasını kaldırmak için [removeWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) yöntemini kullanabilirsiniz. Bu örnek kod bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

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

Genellikle kullanıcılar şifreli veya parola korumalı bir sunumun belge özelliklerini alırken zorlanır. Ancak Aspose.Slides, bir sunumu parola koruması altında tutarken bile kullanıcıların özelliklere erişebilmesine imkan tanıyan bir mekanizma sunar.  

**Not:** Varsayılan olarak Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de parola korumalı olur. Şifreleme sonrasında bile belge özelliklerinin erişilebilir olmasını istiyorsanız, Aspose.Slides bunu tam olarak yapmanıza izin verir.  

Kullanıcıların şifreli bir sunumun özelliklerine erişebilmesini istiyorsanız, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) yöntemine `false` gönderin. Bu örnek kod bir sunumu şifrelerken aynı zamanda kullanıcıların belge özelliklerine erişimini nasıl sağlayacağınızı gösterir:

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

Bir şifreli sunumun slaytlarını veya diğer içeriklerini yüklemeden yalnızca meta verilerini incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) nesnesi oluşturun ve [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) yöntemine `true` gönderin. Bu modda Aspose.Slides parolayı göz ardı eder ve yalnızca genel olarak erişilebilen belge özelliklerini yükler.  

Aşağıdaki kod örneği [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) aracılığıyla yerleşik ve özel belge özelliklerini nasıl okur gösterir:

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

Bu iş akışı yalnızca sunum şifrelenirken belge özellikleri şifrelenmemiş (genel) ise çalışır. Belge özellikleri şifrelenmişse, `loadOptions.setOnlyLoadDocumentProperties`a `true` göndermek bir istisna oluşturur çünkü bu modda parola göz ardı edilir. Şifreli belge özelliklerine erişmek veya slaytlar ve diğer içerikler dahil tam sunumu yüklemek için doğru parolayı [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) aracılığıyla sağlayın.

## **Bir Sunumun Parola Koruması Olarak Belirlenip Belirlenmediğini Kontrol Et**

Bir sunumu yüklemeden önce, sunumun parola ile korunup korunmadığını kontrol etmek isteyebilirsiniz. Bu sayede parola korumalı bir sunumun parolasız yüklenmesiyle ortaya çıkabilecek hatalardan ve benzer sorunlardan kaçınmış olursunuz.  

Bu Java kodu bir sunumun parola korumalı olup olmadığını (sunumu gerçekten yüklemeden) nasıl inceleyeceğinizi gösterir:

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Et**

Aspose.Slides, bir sunumun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum şifreli ise `true`, değilse `false` dönen [isEncrypted](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) özelliğini kullanabilirsiniz.  

Bu örnek kod bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumun Yazma Koruması Olarak Belirlenip Belirlenmediğini Kontrol Et**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum yazma korumalı ise `true`, değilse `false` dönen [isWriteProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) özelliğini kullanabilirsiniz.  

Bu örnek kod bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Belirli Bir Parolanın Kullanıldığını Doğrula veya Onayla**

Bir sunum belgesinin belirli bir parola ile korunup korunmadığını kontrol etmek ve onaylamak isteyebilirsiniz. Aspose.Slides, bir parolayı doğrulamanızı sağlar.  

Bu örnek kod bir parolayı nasıl doğrulayacağınızı gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "\"pass\" ile eşleşip eşleşmediğini kontrol et
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Parola belirtilen şifreyle sunumu şifrelemişse `true`; aksi takdirde `false` döner.  

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/tr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından hangi şifreleme yöntemleri desteklenir?**

Aspose.Slides, modern şifreleme yöntemlerini, özellikle AES tabanlı algoritmaları destekleyerek sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış bir parola girilirse ne olur?**

Yanlış bir parola kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Parola korumalı sunumlarla çalışırken performans üzerinde herhangi bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi çok küçüktür ve sunum görevlerinizin genel işleme süresini önemli ölçüde etkilemez.