---
title: Java'da Şifrelerle Sunumları Güvenli Hale Getirme
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/java/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunum kilidini aç
- PowerPoint koru
- sunumu koru
- şifre ayarla
- şifre ekle
- PowerPoint şifrele
- sunumu şifrele
- PowerPoint şifresini çöz
- sunum şifresini çöz
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
description: "Aspose.Slides for Java ile şifre korumalı PowerPoint ve OpenDocument sunumlarını kolayca nasıl kilitleyeceğinizi ve kilidini açacağınızı öğrenin. Sunumlarınızı güvenceye alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre belirlediğiniz anlamına gelir. Bu kısıtlamaları kaldırmak için şifre girilmelidir. Şifre korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunuma bu kısıtlamaları uygulamak için bir şifre ayarlayabilirsiniz:

- **Değiştirme**

  Eğer sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlamayan kişilerin sunumunuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını engeller.  

  Ancak, şifre olmadan da kullanıcı belgenize erişebilir ve açabilir. Bu yalnızca okuma modunda, kullanıcı sunumunuzdaki içeriği—hiperlinkler, animasyonlar, efektler ve diğer öğeler dahil—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.

- **Açma**

  Eğer sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlamayan kişilerin sunumunuzun içeriğini hatta görüntülemesini engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller—eğer bir kişi sunumu açamazsa, onu değiştiremez veya üzerinde değişiklik yapamaz.

**Not:** Sunumu açılmasını engelleyecek şekilde şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Aspose.Slides'ta Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzer işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumları şifre koruması ile koruyarak değişiklikleri aşağıdaki şekillerde önlemenizi sağlar:

- Sunumu şifrelemek
- Sunuma yazma koruması ayarlamak

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri aşağıdaki şekilde gerçekleştirmenizi sağlar:

- Sunumu şifre çözmek; şifreli bir sunumu açmak
- Şifrelemeyi kaldırmak; şifre korumasını devre dışı bırakmak
- Sunumdan yazma korumasını kaldırmak
- Şifreli bir sunumun özelliklerini almak
- Sunumun şifreli olup olmadığını kontrol etmek
- Sunumun şifre korumalı olup olmadığını kontrol etmek.

## **Sunumu Şifreyle Korumak**

Bir şifre belirleyerek bir sunumu şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcı şifreyi girmelidir.

Bir sunumu şifrelemek veya şifre korumalı hâle getirmek için, sunuma bir şifre ayarlamak amacıyla encrypt metodunu ([IProtectionManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager)) kullanmalısınız. Şifreyi encrypt metoduna geçirirsiniz ve ardından şifrelenmiş sunumu kaydetmek için save metodunu kullanırsınız. 

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sunuma Yazma Koruması Ayarlama**

Sunuma “Değiştirmeyin” ifadesi ekleyebilirsiniz. Bu şekilde, kullanıcılara sunumu değiştirmemeleri gerektiğini bildirirsiniz.  

**Not**: Yazma koruması süreci sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten isterlerse—sunumu değiştirebilir, fakat değişiklikleri kaydetmek için farklı bir adla yeni bir sunum oluşturmak zorunda kalırlar. 

Yazma koruması ayarlamak için, [setWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) metodunu kullanmalısınız. Bu örnek kod, bir sunuma yazma koruması nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Şifreli Bir Sunumu Yükleme**

Aspose.Slides, doğru şifreyi [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) aracılığıyla geçirerek şifreli bir sunumu yüklemenizi sağlar.

Bu örnek kod, şifreli bir sunumu nasıl yükleyeceğinizi gösterir: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // şifre çözülmüş sunumla çalış
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sunumdan Şifrelemeyi Kaldırma**

Bir sunumdaki şifrelemeyi veya şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuma herhangi bir kısıtlama olmadan erişebilir veya değiştirebilir.

Şifrelemeyi veya şifre korumasını kaldırmak için, [removeEncryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#removeEncryption--) metodunu çağırmalısınız. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

```java
import com.aspose.slides.*;

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

## **Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides'i kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar isterleri gibi değiştirebilir ve bu işlemleri yaparken hiçbir uyarı almazlar.  

Sunumdan yazma korumasını kaldırmak için [removeWriteProtection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) metodunu kullanabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Şifreli Bir Sunumun Özelliklerini Alma**

Genellikle, kullanıcılar şifreli veya şifre korumalı bir sunumun belge özelliklerini almada zorlanırlar. Ancak, Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların özelliklerine erişmesini sağlayan bir mekanizma sunar.

**Not:** Varsayılan olarak, Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifre korumalı olur. Şifreleme sonrasında belge özelliklerine erişilebilir olmasını istiyorsanız, Aspose.Slides bunu yapmanıza olanak tanır.

Kullanıcıların şifreli bir sunumun özelliklerine erişebilmesini sağlamak istiyorsanız, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metoduna `false` gönderin. Bu örnek kod, şifreleme yapılırken kullanıcıların belge özelliklerine erişimini nasıl sağlayacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Şifreli Bir Sunumdan Yalnızca Belge Özelliklerini Yükleme**

Şifreli bir sunumun meta verilerini slaytlarını veya diğer içeriklerini yüklemeden incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) nesnesi oluşturun ve [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) metoduna `true` gönderin. Bu modda, Aspose.Slides şifreyi göz ardı eder ve yalnızca herkese açık belge özelliklerini yükler.

Aşağıdaki kod örneği, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDocumentProperties--) aracılığıyla yerleşik ve özel belge özelliklerini okur:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Yerleşik belge özelliklerini okuyun.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Özel belge özelliklerini okuyun.
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

Bu iş akışı yalnızca sunum şifrelenirken belge özellikleri şifrelenmemiş (genel) bırakıldığında çalışır. Belge özellikleri şifrelenmişse, `loadOptions.setOnlyLoadDocumentProperties` metoduna `true` gönderilmesi bir istisna oluşturur çünkü bu modda şifre yok sayılır. Şifreli belge özelliklerine erişmek veya slaytları ve diğer içerikleri de içeren tam sunumu yüklemek için doğru şifreyi [ILoadOptions.setPassword](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) aracılığıyla sağlayın.

## **Sunumun Şifre Korumalı Olup Olmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Böylece, şifre korumalı bir sunum şifre olmadan yüklendiğinde ortaya çıkan hataları ve benzeri sorunları önleyebilirsiniz.

Bu Java kodu, bir sunumun şifre korumalı olup olmadığını (sunumu kendisini yüklemeden) nasıl inceleyeceğinizi gösterir:

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum şifreli ise `true`, şifreli değilse `false` döndüren [isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#isEncrypted--) özelliğini kullanabilirsiniz. 

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum yazma korumalı ise `true`, değilse `false` döndüren [isWriteProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#isWriteProtected--) özelliğini kullanabilirsiniz. 

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Belirli Bir Şifrenin Kullanıldığını Doğrulama veya Onaylama**

Bir sunum belgesini korumak için belirli bir şifrenin kullanılıp kullanılmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli araçları sunar. 

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass" ile eşleşip eşleşmediğini kontrol et
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Belirtilen şifreyle sunum yazma korumalıysa `true` döner; aksi takdirde `false` döner.

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler ve sunumlarınız için yüksek veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış şifre girilirse ne olur?**

Yanlış bir şifre kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans etkileri var mı?**

Şifreleme ve şifre çözme işlemi, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi çok azdır ve sunum görevlerinizin toplam işleme süresini önemli ölçüde etkilemez.