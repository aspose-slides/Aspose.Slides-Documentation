---
title: JavaScript'te Parolalarla Sunumları Güvence Altına Alma
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/nodejs-java/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunumu aç
- PowerPoint koru
- sunumu koru
- parola ayarla
- parola ekle
- PowerPoint şifrele
- sunumu şifrele
- PowerPoint şifre çöz
- sunumu şifre çöz
- yazma koruması
- PowerPoint güvenliği
- sunum güvenliği
- parolayı kaldır
- korumayı kaldır
- şifrelemeyi kaldır
- parolayı devre dışı bırak
- korumayı devre dışı bırak
- yazma korumasını kaldır
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Java üzerinden parola korumalı PowerPoint ve OpenDocument sunumlarını zahmetsizce kilitleyip açabilirsiniz. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu parola korumalı hâle getirdiğinizde, sunuma belirli kısıtlamaları uygulayan bir parola ayarlamış olursunuz. Kısıtlamaları kaldırmak için parola girilmelidir. Parola korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunuma bu kısıtlamaları uygulamak için bir parola ayarlayabilirsiniz:

- **Değişiklik**

  Eğer yalnızca belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzu değiştirmesini, düzenlemesini veya kopyalamasını (parolayı sağlamadıkları sürece) engeller.  

  Ancak bu durumda, parola olmadan da bir kullanıcı belgenize erişip açabilir. Bu yalnızca okuma modunda kullanıcı, sunumunuzdaki içerikleri—hiper bağlantılar, animasyonlar, efektler ve diğer öğeleri—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez. 

- **Açma**

  Eğer yalnızca belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzun içeriğini (parolayı sağlamadıkları sürece) görüntülemesini bile engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumları üzerinde değişiklik yapmasını da engeller: İnsanlar bir sunumu açamadıklarında, onu değiştiremez veya üzerinde değişiklik yapamazlar.  

  **Not**: Bir sunumu açılmasını engellemek amacıyla parola koruması eklediğinizde, sunum dosyası şifrelenir.

## **Sunumu Çevrimiçi Olarak Parola Koruması ile Nasıl Korursunuz**

1. Bizim [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock) sayfamıza gidin. 

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı sürükleyin veya yükleyin**.

3. Bilgisayarınızda parola korumalı hâle getirmek istediğiniz dosyayı seçin. 

4. Düzenleme koruması için tercih ettiğiniz parolayı girin; Görüntüleme koruması için tercih ettiğiniz parolayı girin. 

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız, **Mark as final** kutusunu işaretleyin.

6. **ŞİMDİ KORU.** 

7. **ŞİMDİ İNDİR.**

## **Aspose.Slides'ta Sunumlar İçin Parola Koruması**
**Desteklenen formatlar**

Aspose.Slides bu formatlardaki sunumlar için parola koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumlarda parola koruması kullanarak aşağıdaki yollarla değişiklikleri önlemenizi sağlar:

- Bir sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, parola koruması ve şifreleme ile ilgili diğer görevleri aşağıdaki şekilde gerçekleştirebilir:

- Bir sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; parola korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun parola korumalı olup olmadığını kontrol etme.

## **Bir Sunumu Şifreleme**

Bir sunumu bir parola belirleyerek şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcının parolayı girmesi gerekir. 

Bir sunumu şifrelemek veya parola korumalı hâle getirmek için, sunuma parola belirlemek amacıyla encrypt yöntemini ([ProtectionManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager)) kullanmanız gerekir. Parolayı encrypt yöntemine pasa eder ve ardından save yöntemiyle şifrelenmiş sunumu kaydedersiniz. 

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

Sunuma “Değiştirmeyin” ifadesi ekleyebilirsiniz. Böylece kullanıcılara sunumu değiştirmelerini istemediğinizi bildirebilirsiniz.  

**Not**: Yazma koruma süreci sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten isterlerse—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla yeni bir sunum oluşturmak zorunda kalacaklardır. 

Yazma koruması ayarlamak için [setWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) yöntemini kullanmanız gerekir. Bu örnek kod, bir sunuma yazma koruması nasıl ayarlanır gösterir:

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

## **Bir Sunumu Şifre Çözme; Şifreli Sunumu Açma**

Aspose.Slides, şifreli bir dosyayı parolasını sağlayarak yüklemenizi sağlar. Bir sunumu şifre çözmek için [removeEncryption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) yöntemini parametresiz olarak çağırmanız gerekir. Daha sonra sunumu yüklemek için doğru parolayı girmeniz istenir. 

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // şifrelenmiş sunumla çalış
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Şifrelemeyi Kaldırma; Parola Korumasını Devre Dışı Bırakma**

Bir sunum üzerindeki şifrelemeyi veya parola korumasını kaldırabilirsiniz. Böylece kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir. 

Şifrelemeyi veya parola korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) yöntemini çağırmanız gerekir. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

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

Aspose.Slides'i kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir ve bu işlemler sırasında hiçbir uyarı almazlar.

Sunumdan yazma korumasını [removeWriteProtection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) yöntemiyle kaldırabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

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

## **Şifreli Bir Sunumun Özelliklerini Almak**

Genellikle, kullanıcılar şifreli veya parola korumalı bir sunumun belge özelliklerini almakta zorlanırlar. Ancak Aspose.Slides, bir sunumu parola korumalı hâle getirirken kullanıcıların özelliklerine erişebilmesini sağlayan bir mekanizma sunar.  

**Not:** Varsayılan olarak, Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de parola korumalı olur. Şifrelemeden sonra bile belge özelliklerine erişilebilir olmasını istiyorsanız, Aspose.Slides bunu yapmanıza olanak tanır.  

Eğer kullanıcıların şifreli bir sunumun özelliklerine erişebilme yetisini korumasını istiyorsanız, [ProtectionManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/) üzerindeki `setEncryptDocumentProperties` metoduna `false` değerini geçin. Bu örnek kod, şifreli bir sunumu hala kullanıcıların belge özelliklerine erişebileceği şekilde nasıl şifreleyeceğinizi gösterir:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Şifreli Bir Sunumdan Yalnızca Belge Özelliklerini Yükleme**

Şifreli bir sunumun slaytlarını veya diğer içeriklerini yüklemeden yalnızca meta verilerini incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) nesnesi oluşturup `setOnlyLoadDocumentProperties` metoduna `true` değerini verin. Bu modda Aspose.Slides parolayı yok sayar ve yalnızca herkese açık erişilebilen belge özelliklerini yükler.  

Aşağıdaki kod örneği, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) üzerindeki `getDocumentProperties` yöntemiyle yerleşik ve özel belge özelliklerini okur:

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Yerleşik belge özelliklerini oku.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Özel belge özelliklerini oku.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Bu iş akışı yalnızca sunum şifrelenirken belge özellikleri şifrelenmemiş (halka açık) bırakıldığında çalışır. Belge özellikleri şifreli ise, `LoadOptions.setOnlyLoadDocumentProperties` metoduna `true` geçmek bir istisna oluşturur çünkü bu modda parola yok sayılır. Şifreli belge özelliklerine erişmek veya slaytlar ve diğer içerik dahil tam bir sunumu yüklemek için, [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) üzerindeki `setPassword` metodu ile doğru parolayı sağlayın.  

## **Bir Sunumu Yüklemeden Önce Parola Koruması Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun parola korumalı olup olmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Bu sayede, parola korumalı bir sunum parolasız yüklendiğinde ortaya çıkan hataları ve benzer sorunları önleyebilirsiniz.  

Bu JavaScript kodu, bir sunumun parola korumalı olup olmadığını (sunumu kendisini yüklemeden) incelemenizi gösterir:

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Bir Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum şifreli ise `true`, değilse `false` dönen [isEncrypted](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) özelliğini kullanabilirsiniz.  

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

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum yazma korumalı ise `true`, değilse `false` dönen [isWriteProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) özelliğini kullanabilirsiniz.  

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

## **Belirli Bir Parolanın Sunumu Korumak İçin Kullanıldığını Doğrulama veya Onaylama**

Belirli bir parolanın bir sunum belgesini korumak için kullanılıp kullanılmadığını kontrol etmek ve onaylamak isteyebilirsiniz. Aspose.Slides, bir parolayı doğrulamanız için gerekli araçları sunar.  

Bu örnek kod, bir parolayı nasıl doğrulayacağınızı gösterir:

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

Belirtilen parola ile sunum şifrelenmişse `true`, aksi takdirde `false` döner.  

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından hangi şifreleme yöntemleri desteklenir?**

Aspose.Slides, AES temelli algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler ve sunumlarınız için yüksek düzeyde veri güvenliği sağlar.  

**Bir sunumu açmaya çalışırken yanlış bir parola girilirse ne olur?**

Yanlış bir parola kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği size bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.  

**Parola korumalı sunumlarla çalışırken performans etkileri var mı?**

Şifreleme ve şifre çözme işlemi, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi çok azdır ve sunum görevlerinizin toplam işleme süresini önemli ölçüde etkilemez.