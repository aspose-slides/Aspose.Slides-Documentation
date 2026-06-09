---
title: Java'da Şifrelerle Güvenli Sunumlar
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/java/password-protected-presentation/
keywords:
- PowerPoint'i kilitle
- sunumu kilitle
- PowerPoint'i aç
- sunumu aç
- PowerPoint'i koru
- sunumu koru
- şifre ayarla
- şifre ekle
- PowerPoint'i şifrele
- sunumu şifrele
- PowerPoint'i şifre çöz
- sunumu şifre çöz
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
description: "Aspose.Slides for Java ile şifre korumalı PowerPoint ve OpenDocument sunumlarını kolayca kilitleyip açmayı öğrenin. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarladığınız anlamına gelir. Bu kısıtlamaları kaldırmak için şifre girilmelidir. Şifreyle korunan bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunum üzerinde bu kısıtlamaları uygulamak için bir şifre belirleyebilirsiniz:

- **Değiştirme**

Eğer sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlayana kadar kişilerin sunumunuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını engeller.  

Ancak, şifre olmadan bile bir kullanıcı belgenize erişebilir ve açabilir. Bu yalnızca okuma modunda, kullanıcı sunumunuzdaki içeriği—hiperbağlantılar, animasyonlar, efektler ve diğer öğeler dahil—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.

- **Açma**

Eğer sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlayana kadar kişilerin sunumun içeriğini hatta görüntülemesini engeller.  

Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini engeller—eğer bir sunum açılamıyorsa, üzerinde değişiklik yapılamaz.

**Not:** Sunumu açmayı engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Aspose.Slides'ta Şifre Koruması**

**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumlarda şifre korumasını kullanarak değişiklikleri önlemenize aşağıdaki yöntemlerle izin verir:

- Bir sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri aşağıdaki şekilde gerçekleştirmenizi sağlar:

- Sunumu şifre çözme; şifrelenmiş bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifrelenmiş bir sunumun özelliklerini alma
- Bir sunumun şifrelenip şifrelenmediğini kontrol etme
- Bir sunumun şifreyle korunup korunmadığını kontrol etme.

## **Bir Sunumu Şifreyle Korumak**

Bir şifre ayarlayarak bir sunumu şifreleyebilirsiniz. Ardından, kilitli sunumu değiştirmek için kullanıcı şifreyi sağlamalıdır. 

Bir sunumu şifrelemek veya şifreyle korumak için, sunuma şifre ayarlamak amacıyla encrypt yöntemini ([IProtectionManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager)) kullanmanız gerekir. Şifreyi encrypt yöntemine geçirir ve ardından şifreli sunumu kaydetmek için save yöntemini kullanırsınız. 

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

## **Sunuma Yazma Koruması Ayarlama**

Sunuma “Değiştirmeyin” ifadesini ekleyebilirsiniz. Bu sayede, kullanıcılara sunumu değiştirmelerini istemediğinizi bildirirsiniz.  

**Not**: Yazma koruma süreci sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten istiyorlarsa—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla yeni bir sunum oluşturmak zorunda kalacaklardır. 

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

## **Şifreli Bir Sunumu Yükleme**

Aspose.Slides, şifresini belirterek şifreli bir dosyayı yüklemenize izin verir. Bir sunumu şifre çözmek için, parametresiz olarak [removeEncryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#removeEncryption--) yöntemini çağırmanız gerekir. Ardından sunumu yüklemek için doğru şifreyi girmeniz istenir. 

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
}
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Bir sunumdaki şifreleme veya şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir. 

Şifreleme veya şifre korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#removeEncryption--) yöntemini çağırmanız gerekir. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

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

## **Bir Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides'i kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar istedikleri gibi değiştirebilir ve bu tür işlemler sırasında hiçbir uyarı almazlar.

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

## **Şifreli Bir Sunumun Özelliklerini Almak**

Genellikle, kullanıcılar şifreli veya şifreyle korunan bir sunumun belge özelliklerini almada zorlanırlar. Ancak Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların bu sunumun özelliklerine erişimini sağlayan bir mekanizma sunar.  

**Not**: Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de varsayılan olarak şifre korumasına alınır. Ancak, sunumun özelliklerini (sunum şifrelendikten sonra bile) erişilebilir kılmanız gerekiyorsa, Aspose.Slides tam olarak bunu yapmanıza izin verir.  

Şifrelediğiniz bir sunumun özelliklerine erişim yeteneğini kullanıcıların korumasını istiyorsanız, [encryptDocumentProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) özelliğini `true` olarak ayarlayabilirsiniz. Bu örnek kod, bir sunumu şifrelerken kullanıcıların belge özelliklerine erişmesini nasıl sağlayacağınızı gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumun Şifreyle Korunup Korunmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol edip doğrulamak isteyebilirsiniz. Böylece, şifre korumalı bir sunum şifresi olmadan yüklendiğinde ortaya çıkan hataları ve benzer sorunları önlersiniz.  

Bu Java kodu, bir sunumun şifreyle korunup korunmadığını (sunumu kendisini yüklemeden) incelemenizi gösterir:

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sunumun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum şifrelenmişse `true`, şifrelenmemişse `false` döndüren [isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#isEncrypted--) özelliğini kullanabilirsiniz.  

Bu örnek kod, bir sunumun şifrelenip şifrelenmediğini nasıl kontrol edeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumun Yazma Koruması Alıp Almadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum yazma korumalıysa `true`, değilse `false` döndüren [isWriteProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IProtectionManager#isWriteProtected--) özelliğini kullanabilirsiniz.  

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Belirli Bir Şifrenin Kullanıldığını Doğrulama veya Onaylama**

Bir sunum belgesini korumak için belirli bir şifrenin kullanılıp kullanılmadığını kontrol edip doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli yöntemi sunar.  

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

Belirtilen şifreyle sunum şifrelenmişse `true`, aksi takdirde `false` döndürür.  

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından hangi şifreleme yöntemleri destekleniyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler ve bu sayede sunumlarınız için yüksek düzeyde veri güvenliği sağlar.  

**Bir sunumu açmaya çalışırken yanlış bir şifre girilirse ne olur?**

Yanlış bir şifre kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.  

**Şifreyle korunan sunumlarla çalışırken performans açısından bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi çok azdır ve sunum görevlerinizin genel işleme süresini önemli ölçüde etkilemez.