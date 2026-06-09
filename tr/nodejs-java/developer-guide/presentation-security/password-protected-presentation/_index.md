---
title: "JavaScript'te Şifre ile Sunumları Güvence Altına Alın"
linktitle: "Şifre Koruma"
type: docs
weight: 20
url: /tr/nodejs-java/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunum kilidini aç
- PowerPoint koru
- sunumu koru
- şifre belirle
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile şifre korumalı PowerPoint ve OpenDocument sunumlarını zahmetsizce kilitleyin ve kilidini açın. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarladığınız anlamına gelir. Kısıtlamaları kaldırmak için şifre girilmelidir. Şifre korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunumda bu kısıtlamaları uygulamak için bir şifre ayarlayabilirsiniz:

- **Değişiklik**

  Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların sunumunuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını (şifreyi sağlayıp sağlamamaları koşuluyla) engeller.  

  Ancak bu durumda, şifre olmadan bile bir kullanıcı belgenize erişebilir ve onu açabilir. Bu sadece‑okuma modunda, kullanıcı sunumunuzdaki içerikleri veya öğeleri—hiper bağlantılar, animasyonlar, efektler ve diğerleri—görüntüleyebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.  

- **Açma**

  Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların sunumunuzun içeriğini görmesini (şifreyi sağlamaları koşuluyla) engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller: Kullanıcılar bir sunumu açamadıklarında, üzerinde değişiklik yapamazlar.  

  **Not** sunumu açmayı engellemek için şifre koruması uyguladığınızda, sunum dosyası şifrelenir.

## **Bir Sunumu Çevrimiçi Şifreyle Korumak**

1. Bizim [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock) sayfamıza gidin.  

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı sürükleyin veya yükleyin**'e tıklayın.

3. Bilgisayarınızda şifreyle korumak istediğiniz dosyayı seçin. 

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; görüntüleme koruması için tercih ettiğiniz şifreyi girin. 

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız, **Mark as final** onay kutusunu işaretleyin.

6. **PROTECT NOW.** üzerine tıklayın. 

7. **DOWNLOAD NOW.** üzerine tıklayın.

## **Aspose.Slides'de Sunumlar İçin Şifre Koruması**
**Desteklenen biçimler**

Aspose.Slides bu biçimlerdeki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, bir sunumu aşağıdaki yollarla değişikliklerden korumak için şifre koruması kullanmanıza izin verir:

- Bir sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri aşağıdaki yollarla gerçekleştirmenize olanak tanır:

- Bir sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun şifre korumalı olup olmadığını kontrol etme.

## **Bir Sunumu Şifreleme**

Bir sunumu bir şifre ayarlayarak şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcı şifreyi sağlamalıdır. 

Bir sunumu şifrelemek veya şifreyle korumak için, sunuma şifre ayarlamak amacıyla [ProtectionManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager) içindeki encrypt metodunu kullanmanız gerekir. Şifreyi encrypt metoduna geçirirsiniz ve ardından artık şifreli olan sunumu kaydetmek için save metodunu kullanırsınız.

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Sunuma Yazma Koruması Ayarlama**

Sunuma “Değiştirme” işareti ekleyebilirsiniz. Böylece kullanıcıların sunumu değiştirmesini istemediğinizi belirtebilirsiniz.  

**Not** yazma koruma işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten istediklerinde—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için sunumu farklı bir adla kaydetmek zorunda kalırlar. 

Yazma koruması ayarlamak için [setWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) metodunu kullanmanız gerekir. Bu örnek kod, bir sunuma yazma koruması nasıl ayarlanacağını gösterir:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Sunumu Şifre Çözme; Şifreli Sunumu Açma**

Aspose.Slides, şifresini vererek şifreli bir dosyayı yüklemenize izin verir. Bir sunumu şifre çözmek için, parametresiz olarak [removeEncryption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) metodunu çağırmanız gerekir. Ardından sunumu yüklemek için doğru şifreyi girmeniz istenir.

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // şifre çözülmüş sunumla çalış
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Şifrelemeyi Kaldırma; Şifre Korumasını Devre Dışı Bırakma**

Bir sunumun şifrelemesini veya şifre korumasını kaldırabilirsiniz. Böylece kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir. 

Şifrelemeyi veya şifre korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) metodunu çağırmanız gerekir. Bu örnek kod, bir sunumun şifrelemesini nasıl kaldıracağınızı gösterir:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides'i kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir ve bu tür görevleri gerçekleştirirken hiçbir uyarı almazlar.

Sunumdan yazma korumasını kaldırmak için [removeWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) metodunu kullanabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Şifreli Bir Sunumun Özelliklerini Alma**

Genellikle kullanıcılar şifreli veya şifre korumalı bir sunumun belge özelliklerini almada zorluk çeker. Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların bu sunumun özelliklerine erişebilmesini sağlayan bir mekanizma sunar.  

**Not** Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de varsayılan olarak şifre korumalı olur. Ancak sunum şifrelendikten sonra bile özelliklerin erişilebilir olmasını istiyorsanız, Aspose.Slides tam da bunu yapmanıza izin verir. 

Kullanıcıların şifrelediğiniz bir sunumun özelliklerine erişebilmesini istiyorsanız, [encryptDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) özelliğini `true` olarak ayarlayabilirsiniz. Bu örnek kod, bir sunumu şifrelerken kullanıcıların belge özelliklerine erişebilmesini nasıl sağlayacağınızı gösterir:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Yüklemeden Önce Bir Sunumun Şifre Koruması Olup Olmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifre korumalı olup olmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Böylece şifre korumalı bir sunumun şifresi olmadan yüklenmesi sonucunda ortaya çıkan hataları ve benzeri sorunları önleyebilirsiniz.  

Bu JavaScript kodu, sunumu kendisini yüklemeden şifre korumalı olup olmadığını incelemenizi gösterir:

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Bir Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu görevi gerçekleştirmek için, sunum şifreli ise `true`, şifreli değilse `false` döndüren [isEncrypted](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi gerçekleştirmek için, sunum yazma korumalı ise `true`, değilse `false` döndüren [isWriteProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Belirli Bir Şifrenin Sunumu Korumak İçin Kullanıldığını Doğrulama veya Onaylama**

Bir sunum belgesini korumak için belirli bir şifrenin kullanılıp kullanılmadığını kontrol etmek ve onaylamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli araçları sunar.  

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // "pass" ile eşleşip eşleşmediğini kontrol et
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Şifre belirtilen şifreyle şifrelenmişse `true` döner; aksi takdirde `false` döner. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından hangi şifreleme yöntemleri desteklenir?**

Aspose.Slides, AES tabanlı algoritmalar dahil modern şifreleme yöntemlerini destekleyerek sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Sunumu açmaya çalışırken hatalı bir şifre girilirse ne olur?**

Yanlış şifre kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans açısından herhangi bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu senaryoda bu performans etkisi minimaldir ve sunum görevlerinizin genel işleme süresini önemli ölçüde etkilemez.