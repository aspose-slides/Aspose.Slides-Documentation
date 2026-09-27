---
title: Node.js üzerinden .NET ile PowerPoint'i PDF'ye dönüştür
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 30
url: /tr/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint'ten PDF'ye
- PowerPoint'i PDF'ye dönüştür
- PPTX'den PDF'ye
- PPT'den PDF'ye
- ODP'den PDF'ye
- sunumu PDF olarak kaydet
- PDF/A
- PdfOptions
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET ile JavaScript'te PPTX, PPT ve ODP sunumlarını PDF'ye dönüştürün ve PdfOptions ile arşivleme amaçlı PDF/A dosyaları üretin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via .NET, Microsoft PowerPoint olmadan PowerPoint ve OpenDocument sunumlarını PDF'ye dönüştürür. Görünür her slayt, slaytla aynı boyutta bir PDF sayfasına dönüşür ve metin seçilebilir ve aranabilir kalır. Bu makale, varsayılan dönüştürmeyi ve [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) ile PDF/A dönüştürmesini gösterir.

Örnekler, [Installation](/slides/tr/nodejs-net/installation/) bölümünde kurduğunuz proje klasöründe `sample.pptx` adlı bir sunum dosyası olduğunu varsayar. Herhangi bir PowerPoint sunumu kullanılabilir. Her örneği proje klasöründe bir `.js` dosyası olarak kaydedin ve o klasörden `node` ile çalıştırın.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET'in kendi API referansı yoktur. .NET API'sini camelCase adlarıyla yansıtır, bu yüzden bu makaledeki API bağlantıları [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/tr/net/) üzerindeki eşleşen sınıf ve üyelere yönlendirilir.
{{% /alert %}}

## **Sunumu PDF'ye Dönüştür**

To convert a presentation to PDF, follow these steps:

1. Sunumu, yolunu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/presentation/) yapıcısına geçirerek açın. Aynı kod PPTX, PPT ve ODP dosyaları için çalışır.
1. [save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini çıktı yolu ve `SaveFormat.Pdf` ile çağırın.
1. Sunumu destekleyen .NET kaynaklarını serbest bırakmak için bir `finally` bloğunda `dispose` çağırın.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Betik, `sample.pdf` dosyasını proje klasörüne yazar. Dönüştürme varsayılan ayarları kullanır: gizli olmayan her slayt, slayt sırasına göre bir sayfa olur. Lisans olmadan, her sayfada bir değerlendirme filigranı gösterilir; bakınız [Licensing](/slides/tr/nodejs-net/licensing/).

## **Sunumu PDF/A'ya Dönüştür**

Çıktıyı kontrol etmek için, `save` yönteminin üçüncü bağımsız değişkeni olarak bir [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/) nesnesi geçirin. Aşağıdaki örnek, [compliance](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/compliance/) özelliğini `PdfCompliance.PdfA2b` olarak ayarlar; bu, bir PDF/A-2b dosyası oluşturur. PDF/A, uzun vadeli arşivleme için ISO standardıdır: diğer kuralların yanı sıra, belgenin kullandığı her yazı tipinin dosyaya gömülmesini gerektirir.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Betik, `sample-pdfa.pdf` dosyasını varsayılan dönüştürme ile aynı sayfalarla yazar. Bir dosyanın standarda uygun olduğunu doğrulamak için [veraPDF](https://verapdf.org/) gibi bir PDF/A doğrulayıcıyla kontrol edin. Diğer [PdfCompliance](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfcompliance/) değerleri, `PdfA1b`, `PdfA2a` veya erişilebilirlik için `PdfUa` gibi farklı standartları seçer.

## **SSS**

**PDF'de gizli slaytları nasıl dahil ederim?**

Gizli slaytlar varsayılan olarak atlanır. `PdfOptions` nesnesinin [showHiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/showhiddenslides/) özelliğini `true` olarak ayarlayın ve seçenekleri `save` metoduna geçirin.

**PDF'i bir şifreyle koruyabilir miyim?**

Evet. `save` metodunu çağırmadan önce `PdfOptions` nesnesinin [password](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/password/) özelliğini ayarlayın. PDF okuyucular dosyayı açmadan önce bu şifreyi ister.

**Sadece bazı slaytları dönüştürebilir miyim?**

Evet. `save` metodunun dördüncü bağımsız değişkeni olarak slayt konumlarının bir dizisini geçirin. Konumlar 1'den başlar ve üçüncü bağımsız değişkeni seçenek gerekmediğinde `null` olabilir: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` bir PDF oluşturur ve birinci ve üçüncü slaytları içerir.

**Linux'ta dönüştürürken metin neden farklı görünüyor?**

Aspose.Slides, dönüştürmeyi yapan makinede yüklü olan yazı tiplerini yalnızca kullanabilir. Bir sunum, tipik bir Linux sunucusunda bulunmayan Calibri gibi bir yazı tipi kullanıyorsa, Aspose.Slides yerine yüklü bir yazı tipini kullanır; bu da metnin görünümünü ve satır sonlarını değiştirebilir. Windows'taki aynı sonucu elde etmek için sunumlarınızın kullandığı yazı tiplerini yükleyin.

**PDF'i bir dosya yerine Buffer olarak alabilir miyim?**

Evet. `presentation.saveToBuffer(SaveFormat.Pdf)` PDF'i bir Node.js `Buffer` olarak döndürür; bu, sonucu bir HTTP yanıtında gönderirken uygundur. Ayrıca ikinci bağımsız değişken olarak `PdfOptions` alır.