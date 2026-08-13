---
title: Android'de Şifrelerle Sunumları Güvenceye Al
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/androidjava/password-protected-presentation/
keywords:
- PowerPoint'i Kilitle
- Sunumu Kilitle
- PowerPoint'in Kilidini Aç
- Sunumun Kilidini Aç
- PowerPoint'i Koru
- Sunumu Koru
- Şifre Ayarla
- Şifre Ekle
- PowerPoint'i Şifrele
- Sunumu Şifrele
- PowerPoint'in Şifresini Çöz
- Sunumun Şifresini Çöz
- Yazma Koruması
- PowerPoint Güvenliği
- Sunum Güvenliği
- Şifreyi Kaldır
- Koruma Kaldır
- Şifrelemeyi Kaldır
- Şifreyi Devre Dışı Bırak
- Korumayı Devre Dışı Bırak
- Yazma Korumasını Kaldır
- PowerPoint
- OpenDocument
- Sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java üzerinden kullanarak şifreyle korunan PowerPoint ve OpenDocument sunumlarını zahmetsizce kilitleyip açabilirsiniz. Sunumlarınızı güvenceye alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarlamış olursunuz. Kısıtlamaları kaldırmak için şifre girilmelidir. Şifreyle korunan bir sunum kilitli bir sunum olarak kabul edilir.

Tipik olarak, bir sunuma aşağıdaki kısıtlamaları getirmek için şifre ayarlayabilirsiniz:

- **Değiştirme**

  Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması belirleyebilirsiniz. Bu kısıtlama, insanlar şifreyi sağlamadıkça sunumunuzdaki öğeleri değiştirmelerini, düzenlemelerini veya kopyalamalarını engeller.

  Ancak bu durumda, şifre olmadan bir kullanıcı belgeye erişebilir ve açabilir. Bu yalnızca okuma modunda, kullanıcı içindeki içerikleri—köprüler, animasyonlar, efektler vb.—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.

- **Açma**

  Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması belirleyebilirsiniz. Bu kısıtlama, insanlar şifreyi sağlamadıkça sunumunuzun içeriğini görüntülemelerini bile engeller.

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller: Bir sunum açılamadığında, kullanıcılar üzerinde değişiklik yapamaz.

  **Not** bir sunumu açmayı engelleyecek şekilde şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Aspose.Slides’da Sunumlar İçin Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, aşağıdaki formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX ve PPT – Microsoft PowerPoint Sunumu
- ODP – OpenDocument Sunumu
- OTP – OpenDocument Sunum Şablonu

**Desteklenen işlemler**

Aspose.Slides, sunumlarda aşağıdaki yollarla değiştirmeyi engellemek için şifre koruması kullanmanıza olanak tanır:

- Sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri aşağıdaki yollarla gerçekleştirmenizi sağlar:

- Sunumu şifre çözme; şifrelenmiş bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifrelenmiş bir sunumun özelliklerini alma
- Bir sunumun şifrelenip şifrelenmediğini kontrol etme
- Bir sunumun şifreyle korunduğunu kontrol etme.

## **Bir Sunumu Şifrelemek**

Bir sunumu şifre belirleyerek şifreleyebilirsiniz. Ardından, kilitli sunumu değiştirmek isteyen bir kullanıcı şifreyi girmek zorundadır.

Bir sunumu şifrelemek veya şifreyle korumak için, sunuma şifre ayarlamak amacıyla [IProtectionManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager) arayüzündeki **encrypt** metodunu kullanmanız gerekir. Şifreyi **encrypt** metoduna geçirip, ardından şifrelenmiş sunumu kaydetmek için **save** metodunu kullanırsınız.

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

Sunuma “Değiştirmeyin” işareti ekleyebilirsiniz. Böylece kullanıcıların sunumu değiştirmesini istemediğinizi belirtebilirsiniz.

**Not** yazma koruma işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—istemedikleri takdirde—sunumu değiştirebilir, ancak değişiklikleri kaydetmek istediklerinde farklı bir adla sunum oluşturmak zorunda kalırlar.

Yazma koruması ayarlamak için [setWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) metodunu kullanmanız gerekir. Bu örnek kod, bir sunuma nasıl yazma koruması ekleyeceğinizi gösterir:

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

## **Şifrelenmiş Bir Sunumu Yükleme**

Aspose.Slides, doğru şifreyi **LoadOptions** aracılığıyla geçirerek şifrelenmiş bir sunumu yüklemenize olanak tanır.

Bu örnek kod, şifrelenmiş bir sunumu nasıl açacağınızı gösterir:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // şifre çözülmüş sunum ile çalış
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Bir sunum üzerindeki şifreleme veya şifre korumasını kaldırabilirsiniz. Böylece kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir.

Şifrelemeyi veya şifre korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) metodunu çağırmanız gerekir. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

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

## **Bir Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides, bir sunum dosyasındaki yazma korumasını kaldırmanıza olanak tanır. Böylece kullanıcılar istedikleri gibi değiştirebilir ve böyle bir işlem sırasında uyarı almazlar.

Yazma korumasını kaldırmak için [removeWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) metodunu kullanabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

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

## **Şifrelenmiş Bir Sunumun Özelliklerini Alma**

Kullanıcılar genellikle şifrelenmiş veya şifreyle korunan bir sunumun belge özelliklerini almada zorlanırlar. Ancak Aspose.Slides, bir sunumu şifreyle korurken aynı zamanda kullanıcıların özelliklerine erişebilmesini sağlayan bir mekanizma sunar.

**Not:** Varsayılan olarak Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifreyle korunur. Şifreleme sonrasında belge özelliklerinin erişilebilir olmasını istiyorsanız, Aspose.Slides bu imkanı tam olarak sunar.

Kullanıcıların şifrelenmiş bir sunumun özelliklerine erişebilmesini istiyorsanız, [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metoduna `false` geçirin. Bu örnek kod, kullanıcılara belge özelliklerine erişim sağlarken bir sunumu nasıl şifreleyeceğinizi gösterir:

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

## **Şifrelenmiş Bir Sunumdan Yalnızca Belge Özelliklerini Yükleme**

Şifrelenmiş bir sunumun slaytlarını veya diğer içeriklerini yüklemeden yalnızca meta verilerini incelemek için bir **LoadOptions** nesnesi oluşturun ve **setOnlyLoadDocumentProperties** metoduna `true` geçirin. Bu modda Aspose.Slides şifreyi yok sayar ve yalnızca herkese açık olarak erişilebilen belge özelliklerini yükler.

Aşağıdaki kod örneği, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) aracılığıyla yerleşik ve özel belge özelliklerini okur:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // yerleşik belge özelliklerini oku.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // özel belge özelliklerini oku.
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

Bu iş akışı yalnızca belge özellikleri şifrelenmemiş (herkese açık) olduğunda çalışır. Belge özellikleri şifrelenmişse, `loadOptions.setOnlyLoadDocumentProperties` metoduna `true` geçmek bir istisna oluşturur çünkü bu modda şifre yok sayılır. Şifrelenmiş belge özelliklerine erişmek veya slaytlar ve diğer içerikler dahil tam sunumu yüklemek için doğru şifreyi **ILoadOptions.setPassword** aracılığıyla sağlayın:

{{% alert color="info" title="Ayrıca Bakınız" %}} 
- [Digital Signature in PowerPoint](/slides/tr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Bir Sunumun Şifreyle Korunup Korunmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol etmek isteyebilirsiniz. Böylece şifreli bir sunumu şifresi olmadan yüklemeye çalışırken oluşabilecek hatalardan kaçınırsınız.

Bu Java kodu, bir sunumun şifreyle korunup korunmadığını (sunumu yüklemeden) nasıl inceleyeceğinizi gösterir:

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sunumun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için **isEncrypted** özelliğini kullanabilirsiniz; bu özellik sunum şifreli ise `true`, değilse `false` döndürür.

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

## **Bir Sunumun Yazma Koruması Altında olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma koruması altında olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için **isWriteProtected** özelliğini kullanabilirsiniz; bu özellik sunum yazma korumalı ise `true`, değilse `false` döndürür.

Bu örnek kod, bir sunumun yazma koruması altında olup olmadığını nasıl kontrol edeceğinizi gösterir:

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

Bir sunum belgesinin belirli bir şifreyle korunup korunmadığını kontrol ve onaylamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanızı sağlayan bir yol sunar.

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // \"pass\" şifresinin eşleşip eşleşmediğini kontrol et
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Şifre belirtilen şifreyle yazma koruması uygulanmışsa `true` döndürür; aksi takdirde `false` döndürür.

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, modern şifreleme yöntemlerini, özellikle AES tabanlı algoritmaları destekleyerek sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Sunumu açmaya çalışırken yanlış şifre girilirse ne olur?**

Yanlış şifre kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifreyle korunan sunumlarla çalışırken performans açısından bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında çok hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi oldukça düşüktür ve genel sunum iş akışınızın süresini önemli ölçüde etkilemez.