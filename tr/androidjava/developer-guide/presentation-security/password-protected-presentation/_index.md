---
title: Android'de Şifrelerle Sunumları Güvence Altına Alın
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/androidjava/password-protected-presentation/
keywords:
- PowerPoint'i kilitle
- sunumu kilitle
- PowerPoint'i aç
- sunumu aç
- PowerPoint'i koru
- sunumu koru
- şifre belirle
- şifre ekle
- PowerPoint'i şifrele
- sunumu şifrele
- PowerPoint'in şifresini çöz
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden şifre korumalı PowerPoint ve OpenDocument sunumlarını zahmetsizce kilitleyip açın. Sunumlarınızı güvenceye alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunum üzerindeki belirli kısıtlamaları zorlayan bir şifre ayarladığınız anlamına gelir. Kısıtlamaları kaldırmak için şifre girilmelidir. Şifre korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunumda bu kısıtlamaları uygulamak için bir şifre belirleyebilirsiniz:

- **Değiştirme**

  Eğer sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifre sağlanmadıkça, insanların sunumunuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını önler.

  Ancak bu durumda, şifre olmadan bile bir kullanıcı belgenize erişip açabilir. Bu salt okunur modda, kullanıcı sunumunuzdaki içerikleri—hiperlinkler, animasyonlar, efektler ve diğer öğeleri—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.

- **Açma**

  Eğer sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifre sağlanmadıkça, insanların sunumunuzun içeriğini bile görüntülemesini engeller.

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller: İnsanlar bir sunumu açamadığında, üzerinde değişiklik yapamazlar.

**Not** bir sunumu açmayı engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Aspose.Slides'da Sunumlar için Şifre Koruması**
**Desteklenen biçimler**

Aspose.Slides bu biçimlerdeki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX and PPT - Microsoft PowerPoint Sunumu
- ODP - OpenDocument Sunumu
- OTP - OpenDocument Sunum Şablonu

**Desteklenen işlemler**

Aspose.Slides, sunumlar üzerinde şifre koruması kullanarak değişiklikleri önlemenizi bu yollarla sağlar:

- Bir sunumu şifreleme
- Bir sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri şu şekilde gerçekleştirmenizi sağlar:

- Bir sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Bir sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun şifre korumalı olup olmadığını kontrol etme

## **Bir Sunumu Şifreleme**

Bir sunumu şifre ayarlayarak şifreleyebilirsiniz. Ardından, kilitli sunumu değiştirmek için kullanıcının şifreyi sağlaması gerekir.

Bir sunumu şifrelemek veya şifre korumalı hâle getirmek için, sunuma şifre ayarlamak amacıyla encrypt metodunu ([IProtectionManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager) üzerinden) kullanmanız gerekir. Şifreyi encrypt metoduna geçirir ve ardından kaydetme metodunu kullanarak artık şifreli sunumu kaydedersiniz.

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

## **Bir Sunuma Yazma Koruması Ayarlama**

Bir sunuma “Değiştirmeyin” ibaresi ekleyebilirsiniz. Bu sayede, kullanıcılara sunumda değişiklik yapmamalarını söylemiş olursunuz.

**Not**: Yazma koruması işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten istiyorlarsa—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla sunum oluşturmak zorunda kalırlar.

Yazma koruması ayarlamak için, [setWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) metodunu kullanmanız gerekir. Bu örnek kod, bir sunuma nasıl yazma koruması ekleyeceğinizi gösterir:

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

Aspose.Slides, şifreli bir dosyayı şifresini vererek yüklemenizi sağlar. Bir sunumu şifre çözmek için, [removeEncryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) metodunu parametresiz olarak çağırmanız gerekir. Ardından, sunumu yüklemek için doğru şifreyi girmeniz istenir.

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // şifresi çözülen sunumla çalış
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Bir sunumdaki şifreleme veya şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir.

Şifrelemeyi veya şifre korumasını kaldırmak için, [removeEncryption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) metodunu çağırmanız gerekir. Bu örnek kod, bir sunumdan nasıl şifreleme kaldırılacağını gösterir:

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

Aspose.Slides'ı kullanarak bir sunum dosyasında kullanılan yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar diledikleri gibi değiştirebilir ve bu işlemleri yaparken hiçbir uyarı almazlar.

Bir sunumdaki yazma korumasını [removeWriteProtection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) metodunu kullanarak kaldırabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Şifreli Bir Sunumun Özelliklerini Alma**

Genellikle, kullanıcılar şifreli veya şifre korumalı bir sunumun belge özelliklerini almada zorluk çeker. Ancak Aspose.Slides, bir sunumu şifre korumalı hâle getirirken kullanıcıların o sunumun özelliklerine erişebilmesini sağlayan bir mekanizma sunar.

**Not** Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de varsayılan olarak şifre korumalı hâle gelir. Ancak sunumun özelliklerinin (sunum şifrelenmiş olsa bile) erişilebilir olmasını istiyorsanız, Aspose.Slides bunu tam olarak yapmanıza imkan verir.

Eğer şifrelediğiniz bir sunumun özelliklerine kullanıcıların erişebilme yetisini sürdürmesini istiyorsanız, [encryptDocumentProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) özelliğini `true` olarak ayarlayabilirsiniz. Bu örnek kod, kullanıcıların belge özelliklerine erişebilmesini sağlayarak bir sunumu nasıl şifreleyeceğinizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumun Şifre Koruması Olup Olmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol edip doğrulamak isteyebilirsiniz. Bu sayede, şifre korumalı bir sunum şifresi olmadan yüklendiğinde ortaya çıkan hata ve benzeri sorunlardan kaçınmış olursunuz.

Bu Java kodu, bir sunumun şifre korumalı olup olmadığını (sunumu yüklemeden) incelemenizi gösterir:

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sunumun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu işlemi yapmak için, sunum şifreli ise `true`, değilse `false` döndüren [isEncrypted](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun şifreli olup olmadığını kontrol etmenizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu işlemi yapmak için, sunum yazma korumalı ise `true`, değilse `false` döndüren [isWriteProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi gösterir:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Belirli Bir Şifrenin Kullanıldığını Doğrulama veya Onaylama**

Sunum belgesini korumak için belirli bir şifrenin kullanıldığını kontrol edip doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanızı sağlayan araçlar sunar.

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

Şifreyle korunmuş bir sunumu şifreyle açmak için, şifre doğruysa `true`, aksi takdirde `false` döner.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'te Dijital İmza](/slides/tr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler; bu da sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış bir şifre girilirse ne olur?**

Yanlış bir şifre kullanılırsa bir istisna fırlatılır ve sunuma erişimin reddedildiği konusunda uyarı alırsınız. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans etkileri var mı?**

Şifreleme ve şifre çözme işlemi, açma ve kaydetme sırasında hafif bir ek yük getirebilir. Çoğu durumda bu performans etkisi çok küçüktür ve sunum görevlerinizin toplam işlem süresini önemli ölçüde etkilemez.