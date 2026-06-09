---
title: C++'ta Parolalarla Güvenli Sunumlar
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/cpp/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunum kilidini aç
- PowerPoint koru
- sunumu koru
- parola belirle
- parola ekle
- PowerPoint şifrele
- sunumu şifrele
- PowerPoint şifresini çöz
- sunumu şifresini çöz
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile parola korumalı PowerPoint ve OpenDocument sunumlarını zahmetsizce kilitleme ve kilidini açma yöntemlerini öğrenin. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belli kısıtlamalar getiren bir şifre belirlemiş olursunuz. Kısıtlamaları kaldırmak için şifre girilmelidir. Şifreyle korunan bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunuma aşağıdaki kısıtlamaları uygulamak için şifre ayarlayabilirsiniz:

- **Değiştirme**

  Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların sunumunuzdaki içerikleri değiştirmesini, düzenlemesini veya kopyalamasını (şifreyi sağlamaları koşuluyla) engeller. 

  Ancak, bu durumda şifre olmadan da bir kullanıcı belgenize erişip açabilir. Bu sadece‑okuma modunda kullanıcı, sunumunuzdaki hiperlinkler, animasyonlar, efektler ve diğer öğeleri görüntüleyebilir; ancak öğeleri kopyalayamaz veya sunumu kaydedemez. 

- **Açma**

  Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların sunumunuzun içeriğini (şifreyi sağlamaları koşuluyla) görmesini engeller.

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumunuzu değiştirmesini de engeller: Kullanıcılar bir sunumu açamadıklarında, onu değiştiremezler. 
  
  **Not** bir sunumu açmayı engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Sunumu Çevrimiçi Şifreyle Korumak**

1. **Aspose.Slides Kilitle** sayfamıza gidin: [**Aspose.Slides Kilitle**](https://products.aspose.app/slides/tr/lock).

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı sürükleyin veya yükleyin** üzerine tıklayın.

3. Bilgisayarınızdan şifrelemek istediğiniz dosyayı seçin.

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; görüntüleme koruması için tercih ettiğiniz şifreyi girin.

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız **Nihai olarak işaretle** kutusunu işaretleyin.

6. **ŞİMDİ KORU** düğmesine tıklayın.

7. **ŞİMDİ İNDİR** düğmesine tıklayın.

## **Aspose.Slides’ta Sunumlar İçin Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, aşağıdaki formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX ve PPT – Microsoft PowerPoint Sunumu  
- ODP – OpenDocument Sunumu  
- OTP – OpenDocument Sunumu Şablonu  

**Desteklenen işlemler**

Aspose.Slides, sunumları aşağıdaki yöntemlerle değiştirmeyi önlemek için şifre koruması kullanmanıza izin verir:

- Sunumu şifreleme  
- Sunuma yazma koruması uygulama  

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili şu ek görevleri gerçekleştirmenizi sağlar:

- Sunumu şifre çözme; şifreli bir sunumu açma  
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma  
- Bir sunumdan yazma korumasını kaldırma  
- Şifreli bir sunumun özelliklerini alma  
- Bir sunumun şifrelenip şifrelenmediğini kontrol etme  
- Bir sunumun şifreyle korunup korunmadığını kontrol etme.

## **Bir Sunumu Şifrelemek**

Bir şifre belirleyerek bir sunumu şifreleyebilirsiniz. Kilitli sunumu değiştirmek isteyen kullanıcının şifreyi sağlaması gerekir. 

Bir sunumu şifrelemek veya şifreyle korumak için, [ProtectionManager](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager) sınıfındaki `encrypt` metodunu kullanarak sunuma bir şifre atamanız gerekir. Şifreyi `encrypt` metoduna geçirip ardından `save` metoduyla şimdi şifreli olan sunumu kaydedersiniz. 

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Bir Sunuma Yazma Koruması Ayarlama**

Sunuma “Değiştirmeyin” işareti ekleyebilirsiniz. Böylece kullanıcılara sunumu değiştirmemelerini bildirirsiniz.  

**Not** yazma koruma süreci sunumu şifrelemez. Bu nedenle, kullanıcılar – gerçekten isterlerse – sunumu değiştirebilir; ancak değişiklikleri kaydetmek için farklı bir adla yeni bir sunum oluşturmak zorunda kalırlar. 

Yazma koruması ayarlamak için `setWriteProtection` metodunu kullanmanız gerekir. Bu örnek kod, bir sunuma yazma koruması nasıl ekleyeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Şifreli Bir Sunumu Yükleme**

Aspose.Slides, bir şifreyi geçerek şifreli bir dosyayı yüklemenize olanak tanır. Bir sunumu şifre çözmek için parametresiz olarak [RemoveEncryption](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metodunu çağırmanız gerekir. Ardından sunumu yüklemek için doğru şifreyi girmeniz istenir. 

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// şifre çözülmüş sunumla çalış
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Bir sunumun şifrelemesini veya şifre korumasını kaldırabilirsiniz. Böylece kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir. 

Şifrelemeyi veya şifre korumasını kaldırmak için [RemoveEncryption](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metodunu çağırmanız gerekir. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Bir Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar diledikleri gibi değiştirebilir ve bu işlemler sırasında hiçbir uyarı almazlar.

Yazma korumasını kaldırmak için [RemoveWriteProtection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) metodunu kullanın. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Şifreli Bir Sunumun Özelliklerini Alma**

Genellikle kullanıcılar, şifreli veya şifreyle korunan bir sunumun belge özelliklerini almada zorluk çeker. Aspose.Slides ise, bir sunumu şifreyle korurken aynı zamanda kullanıcıların o sunumun özelliklerine erişebilmesini sağlayan bir mekanizma sunar.

**Not** Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de varsayılan olarak şifreyle korunur. Ancak, sunum şifrelendikten sonra bile özelliklerin erişilebilir olmasını istiyorsanız, Aspose.Slides bunu yapmanıza izin verir. 

Kullanıcıların şifrelediğiniz bir sunumun özelliklerine erişebilmesini istiyorsanız, [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) metoduna `true` parametresi geçirebilirsiniz. Bu örnek kod, kullanıcıların belge özelliklerine erişebildiği şekilde bir sunumu nasıl şifreleyeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Bir Sunumun Şifreyle Korunup Korunmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol etmek isteyebilirsiniz. Böylece şifre korumalı bir sunum şifresi olmadan yüklendiğinde ortaya çıkabilecek hataları ve benzeri sorunları önlersiniz.

Bu C++ kodu, bir sunumun şifreyle korunup korunmadığını (sunumu yüklemeden) nasıl inceleyeceğinizi gösterir:

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum şifreli ise `true`, şifreli değilse `false` döndüren [get_IsEncrypted()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) metodunu kullanabilirsiniz. 

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Bir Sunumun Yazma Koruması Altında Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma koruması altında olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum şifreli ise `true`, şifreli değilse `false` döndüren [get_IsWriteProtected()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) metodunu kullanabilirsiniz. 

Bu örnek kod, bir sunumun yazma koruması altında olup olmadığını nasıl kontrol edeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Sunum Şifresi Kullanımını Doğrulama**

Belirli bir şifrenin bir sunum belgesini korumak için kullanılıp kullanılmadığını kontrol etmek ve onaylamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanıza olanak tanır. 

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// "pass" ile eşleşip eşleşmediğini kontrol et
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Şifre belirtilen şifreyle şifrelenmişse `true`, aksi takdirde `false` döndürür. 

{{% alert color="primary" title="See also" %}} 
- [PowerPoint’te Dijital İmza](/slides/tr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından desteklenen şifreleme yöntemleri nelerdir?**

Aspose.Slides, modern şifreleme yöntemlerini, özellikle AES tabanlı algoritmaları destekler; bu da sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış şifre girilirse ne olur?**

Yanlış şifre kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifreyle korunan sunumlarla çalışırken performans açısından bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu senaryoda bu performans etkisi en az seviyededir ve sunum görevlerinizin toplam işleme süresini önemli ölçüde etkilemez.