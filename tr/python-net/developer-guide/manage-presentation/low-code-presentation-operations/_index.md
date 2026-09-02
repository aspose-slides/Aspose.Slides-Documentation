---
title: Python'da Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/python-net/low-code-presentation-operations/
keywords:
- düşük kodlu sunum API
- sunumu dönüştür
- sunumları birleştir
- şekilleri topla
- sunumu sıkıştır
- kullanılmayan master slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python'da Aspose.Slides düşük kodlu API'sini kullanarak sunumları dönüştürün ve birleştirin, şekilleri toplayın ve sunum boyutunu azaltın."
---
## **Genel Bakış**

aspose.slides.lowcode modülü, ortak sunum işlemleri için yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne‑modeli iş akışlarını odaklanmış yöntemlerde sarar; böylece dosyaları dönüştürebilir veya birleştirebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Low-code yardımcıları, işlem tüm bir dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyduğunda en yararlı olur. Bireysel slaytlar, master'lar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam Aspose.Slides nesne modelini kullanın.

Aşağıdaki tablo, mevcut yardımcıları özetler:

| Yardımcı | Kullanım amacı |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/convert/) | Sunumu doğrudan dosyadan dosyaya çağrı ile başka bir formata dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [Collect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/collect/) | Tam sunumdan şekilleri alarak tekrar tekrar işleme veya analiz yapma. |
| [Compress](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü yazı tipi verilerini azaltma. |

## **Sunumu Dönüştürme**

Çıktı dosya uzantısının dışa aktarma formatını seçmek için yeterli olduğu durumlarda Convert.auto_by_extension kullanın. Metot, kaynak sunumu açar, çıktı yolundan gerekli formatı belirler ve sonucu yazar.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Convert sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sunar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz gerektiğinde veya seçilen yardımcı tarafından sunulmayan bir dışa aktarma seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçime özgü iş akışları ve seçenekler için [Convert Presentation](/slides/tr/python-net/convert-presentation/) bölümüne bakın.

## **Sunumları Birleştirme**

Tam sunum dosyalarını tek bir çağrı ile birleştirmek için Merger.process kullanın. Girdi sunumlarının aynı dosya formatında olması gerekir.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Tüm slaytların tek bir sonuca, tek tek seçilmeden veya yeniden eşlenmeden eklenmesi gerektiğinde bu yardımcı uygundur. Seçili slaytları birleştirmeniz, hedef bir master veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uzlaştırmanız gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Merge Presentations](/slides/tr/python-net/merge-presentation/) bölümüne bakın.

## **Şekilleri Toplama**

Bir sunumdaki tüm şekillerin bir koleksiyonuna ihtiyacınız olduğunda Collect.shapes kullanın. Aynı kümenin birden çok kez filtrelenmesi, sayılması veya işlenmesi gerektiğinde bu faydalıdır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Gezinti sırası, erken çıkış, işleme öncesi filtreleme veya ayrıntılı üst‑alt kontrolü önemli olduğunda doğrudan koleksiyon döngüleri kullanın.

## **Sunum İçeriğini Sıkıştırma**

Compress sınıfı, kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) hiçbir normal slaytın başvurduğu düzen slaytlarını kaldırır.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) artık kullanılmayan master slaytları kaldırır.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) gömülü yazı tiplerinden kullanılmayan karakterleri kaldırır.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Kullanılmayan masterları kaldırmadan önce kullanılmayan düzenleri kaldırın, böylece düzen temizliğinden sonra başvuru kaybeden bir master da kaldırılabilir. Orijinal master, düzen veya tam gömülü yazı tipi verilerine daha sonra ihtiyaç duyabilecekseniz optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/slides/tr/python-net/slide-master/) ve [Embedded Font](/slides/tr/python-net/embedded-font/) bölümlerine bakın.

## **SSS**

**Low-code API'yi tam nesne modeline ne zaman kullanmalıyım?**  
Standart bir işlem tüm bir dosya veya sunuma uygulandığında ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmediğinde low-code yardımcılarını kullanın. Belirli slaytları seçmeniz, master ve düzen ilişkilerini kontrol etmeniz, ara durumu incelemeniz veya yardımcı tarafından sunulmayan davranışı yapılandırmanız gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**  
Hayır. Merger.process, giriş sunumlarının aynı formatta olmasını ister. Önce giriş dosyalarını ortak bir formata dönüştürün, örneğin Convert.auto_by_extension ile, ardından dönüştürülmüş dosyaları birleştirin.

**Collect.shapes ne içerir?**  
Collect.shapes, sunumdan şekilleri alır; böylece bunlar korunabilir, filtrelenebilir, sayılabilir veya birden çok kez gezilebilir. Hangi slayt tiplerinin veya iç içe nesnelerin ziyaret edileceği üzerinde kesin kontrol gerektiğinde doğrudan koleksiyon döngüleri kullanın.

**Compress her zaman sunum dosyasını küçültür mü?**  
Mutlaka değil. Sonuç, sunumun kullanılmayan düzenler, kullanılmayan masterlar veya kullanılmayan karakterlere sahip gömülü yazı tipleri içerip içermediğine bağlıdır. Bu öğeler yoksa ilgili Compress işlemleri dosya boyutunu azaltmayabilir.

**Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**  
Hayır. Bu yardımcılar, bellekte yüklü Presentation nesnesi üzerinde çalışır. Compress'i çalıştırdıktan sonra sonucu yazmak için Presentation.save metodunu çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştürme](/slides/tr/python-net/convert-presentation/)
- [Sunumları Birleştirme](/slides/tr/python-net/merge-presentation/)
- [Slide Master](/slides/tr/python-net/slide-master/)
- [Metin Kutusunu Yönet](/slides/tr/python-net/manage-textbox/)
- [Gömülü Yazı Tipi](/slides/tr/python-net/embedded-font/)