---
title: Lisanslama
description: "Aspose.Slides for Node.js via .NET için bir lisans dosyası uygulayın, değerlendirme sürümü sınırlamalarını görün ve test amaçlı ücretsiz 30 günlük geçici lisans alın."
type: docs
weight: 80
url: /tr/nodejs-net/licensing/
---
## **Genel Bakış**

Aspose.Slides for Node.js via .NET, değerlendirme ve üretim için tek bir npm paketidir. Lisans olmadan değerlendirme modunda çalışır. Bir lisans satın aldığınızda veya ücretsiz 30 günlük geçici bir lisans aldığınızda, birkaç satır kodla uygularsınız ve değerlendirme kısıtlamaları artık geçerli olmaz.

{{% alert color="info" title="Note" %}}
Aspose ürünlerini değerlendirme, lisanslama ve satın alma ile ilgili genel politikalar [Purchase Policies and FAQ](https://purchase.aspose.com/policies) adresinde toplanmıştır. Fiyatlar [Pricing Information](https://purchase.aspose.com/pricing/slides/tr/family) sayfasında listelenmiştir.
{{% /alert %}}

## **Değerlendirme Sürümü Kısıtlamaları**

Değerlendirme sürümü, ürünün tam işlevselliğini sağlar, ancak iki kısıtlama içerir:

- **Filigran.** Kaydettiğiniz her sunumdaki her slayt, bir değerlendirme filigranı alır: slaytın ortasında "Evaluation only" (Sadece Değerlendirme) yazan kilitli bir metin kutusu. Aynı filigran PDF, XPS ve HTML dışa aktarımlarda ve slayt görüntülerinde de görüntülenir.
- **Kısaltılmış metin.** Kodunuzun bir metin çerçevesinden, paragraftan veya kısmından okuduğu metin, ilk beş karakterine kesilir ve ardından "... text has been truncated due to evaluation version limitation." uyarısı eklenir. Markdown ve HTML5 dışa aktarmaları da aynı şekilde kesilir. Kodunuzun yazdığı metin tam olarak kaydedilir.

[Aspose.Slides'i Değerlendirin](/slides/tr/nodejs-net/evaluate-aspose-slides/) her iki kısıtlamayı ayrıntılı olarak açıklar ve bunları gösteren bir komut dosyası içerir.

{{% alert color="success" title="Tip" %}}
Değerlendirme kısıtlamaları olmadan Aspose.Slides'i test etmek için ücretsiz **30 günlük geçici lisans** isteyin. Ayrıntılar için [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Lisans Hakkında**

Lisans, ürün adı, lisanslı geliştirici sayısı ve abonelik son tarihi gibi ayrıntıları içeren düz metin XML dosyasıdır. Dosya dijital olarak imzalanmıştır, bu nedenle değiştirmeyin: yanlışlıkla eklenen ekstra bir satır sonu bile lisansı geçersiz kılar.

## **Lisansı Uygula**

Lisansı, `License` sınıfının `setLicense` yöntemiyle uygulayın. Her süreçte bir kez, herhangi bir `Presentation` nesnesi oluşturmadan önce çağırın. Tekrar çağırmak zarar vermez, ancak zaten yapılmış işi tekrar eder.

Aşağıdaki komut dosyası, `Aspose.Slides.lic` adlı bir dosyadan lisans uygular. İsmi, lisans dosyanızın adı veya tam yolu ile değiştirin; dosyanın adı ne olursa olsun olabilir.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Bir dosya adı veya göreli yol, `node` çalıştırdığınız geçerli klasöre göre çözülür. Lisans dosyasını proje klasörünüzde tutun ve komut dosyalarınızı oradan çalıştırın veya tam yolu belirtin.

Dosya bulunamazsa veya geçerli bir lisans değilse, `setLicense` bir hata fırlatır ve Aspose.Slides değerlendirme modunda kalır. Komut dosyası hatayı yakalar ve mesajını görüntüler. Eksik bir dosya için mesaj, `License "Aspose.Slides.lic" doesn't exist or access is restricted.` ile başlar ve aranan tüm konumları listeler.

Bu pakette, lisans yalnızca bir dosyadan uygulanır. `License` bir akışı kabul etmez ve paket ölçülü lisanslamayı ortaya koymaz. Paketin sarmaladığı sınıf için Aspose.Slides for .NET API referansındaki [License](https://reference.aspose.com/slides/tr/net/aspose.slides/license/) bölümüne bakın.