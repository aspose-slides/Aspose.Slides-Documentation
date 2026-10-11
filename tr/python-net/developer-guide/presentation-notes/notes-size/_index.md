---
title: Python'da Not Sayfası Boyutunu ve Yönünü Değiştir
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/python-net/notes-size/
keywords:
- not sayfası boyutu
- not yönü
- yatay notlar
- dikey notlar
- el ilanı boyutu
- PowerPoint
- sunum
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile not sayfası boyutlarını okuyun ve değiştirin, yönü değiştirin, kaydedilen boyutları doğrulayın ve notları veya el ilanlarını PDF ve görüntülere dışa aktarın."
---
## **Genel Bakış**

Sunumun not sayfası ayarlarına erişmek için [Presentation.notes_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/notes_size/) kullanın. Bu, [size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notessize/size/) özelliği yazılabilir olan bir [NotesSize](https://reference.aspose.com/slides/tr/python-net/aspose.slides/notessize/) nesnesi döndürür. Ayar nesnesi salt okunsa da, boyut özelliğine yeni boyutlar atayabilirsiniz.

Genişlik ve yükseklik **nokta** cinsinden belirtilir, inç başına 72 nokta vardır. Örneğin, 900 × 600 nokta 12,5 × 8⅓ inçtir. Bu ayarlar bireysel slayt notlarından ziyade sunuma uygulanır.

| Ayar | Amaç |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/notes_size/) | Not sayfası boyutlarını ve el ilanı dışa aktarımında kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation.slide_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slide_size/) | Normal sunum slaytı boyutlarını [SlideSize](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/) aracılığıyla kontrol eder. |

Her iki ayarın değiştirilmesi diğerini otomatik olarak değiştirmez. Not sayfası yönünün değiştirilmesi ayrıca normal slaytları döndürmez. Normal slaytları yeniden boyutlandırmak için [Slide Size](/slides/tr/python-net/slide-size/) sayfasına bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarma örnekleri için en az bir slaytta konuşmacı notları bulunan bir sunum kullanın. Her örnek bağımsız olarak çalıştırılabilir.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

Genişlik ve yüksekliği okuyup karşılaştırarak yönü belirleyin: daha geniş bir sayfa yatay, daha yüksek bir sayfa dikey, eşit boyutlar ise kare sayfa tanımlar. Bu örnek gerçek boyutları nokta cinsinden yazdırır, standart bir kağıt boyutu varsaymaz.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Kağıt Boyutunu Değiştirmeden Yatay Mod’a Geç**

Yalnızca yönü değiştirmek için mevcut genişlik ve yüksekliği yer değiştirin. Bu, özelleştirilmiş bir kağıt boyutu da dahil olmak üzere her iki kenarın uzunluğunu korur. Aşağıdaki koşul, zaten yatay olan bir sayfanın tekrar dikeye geçmesini engeller ve kare bir sayfayı değiştirmez.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Dikey yön için, `size.width > size.height` olduğunda aynı atamayı kullanın. Kağıt boyutunu değiştirmek istemediğiniz sürece A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Not Sayfası Boyutu Ayarlama ve Doğrulama**

Her iki boyutu birlikte atayın, ardından sunumu kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) kullanın. Bu örnek 900 × 600 noktalık bir yatay sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı tekrar açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0.01 nokta toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Beklenen sonuç `900 x 600 nokta` ve `Size preserved: True` şeklindedir. Yeni açılan bir sunumu kontrol etmek, kaydedilen dosyayı doğrular, yalnızca bellek içi ayarları değil.

## **Notları ve El İlanlarını Dışa Aktarma**

Sayfa boyutları, notlar veya el ilanı düzenleri için mevcut alanı tanımlar. Bu düzenleri yalnızca kendileri etkinleştirmez; dışa aktarma seçeneklerini de yapılandırmanız gerekir. Normal slayt dışa aktarımı slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG’ye Dışa Aktarma**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) nesnesini [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) özelliğine atayarak PDF’ye notları ekleyin. Bu örnek ayrıca [Slide.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/) kullanarak notlu ilk slaytı PNG olarak render eder.

[BOTTOM_TRUNCATED](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notespositions/) modu notları tek bir sayfada tutar; sığmayan notlar kırpılabilir. PDF 900 × 600 noktalık sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG 900 × 600 piksel olur. Noktalar sayfa geometrisini, pikseller ise raster çıktıyı tanımlar; boyutlar ayrıca render ölçeğine bağlıdır.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Uzun notlarla PDF dışa aktarımı için [BOTTOM_FULL](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notespositions/) gerektiği kadar ek sayfa sağlar. Yukarıdaki tek slayt görüntü çağrısı bu modu desteklemediği için kullanmayın. Yeniden boyutlandırdıktan sonra, kırpılmış notları ve mevcut not-master nesnelerinin yerleşimini kontrol edin; sadece sayfa boyutlarını değiştirmek, tüm içeriğin sığacağı garantisi değildir. Not dışa aktarımı hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/python-net/convert-powerpoint-to-pdf-with-notes/) sayfasına bakın.

### **El İlanlarını PDF’ye Dışa Aktarma**

Bir sayfada birden çok slayt küçük resimlerini göstermek için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handoutlayoutingoptions/) kullanın. Aşağıdaki örnek 900 × 600 noktalık bir sayfa ayarlar ve sayfa başına dört slayta kadar düzenlemek için [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handouttype/) kullanır. Yatay ön ayar slayt sıralamasını kontrol eder; sayfa yönü genişlik ve yüksekliğinden gelir.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Sayfa boyutunu değiştirmek, kaynak slaytların boyutlarını etkilemeden el ilanı ızgarası için mevcut alanı değiştirir. El ilanı görüntüleri için, tek bir slaytın görüntü yöntemine değil, el ilanı düzeniyle birlikte [Presentation.get_images](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/get_images/) kullanın. Aspose.Slides içinde, sunum seviyesindeki el ilanı renderlaması not sayfası boyutlarını kullanırken, bireysel slayt görüntü çağrısı el ilanı sayfası üretmez. Düzen seçenekleri için [Handout Mode](/slides/tr/python-net/convert-powerpoint-in-handout-mode/) sayfasına bakın.

## **Görüntüleyicilerde, Dışa Aktarmada ve Yazdırmada Sayfa Boyutu**

Kaydedilen sunum boyutunu, dışa aktarılan sayfa boyutunu ve yazdırılan kağıt boyutunu ayrı tutun:

- **Sunum görüntüleyicileri:** Bir görüntüleyici, kendi düzen kurallarını kullanarak notları görüntüleyebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, yeniden açın ve boyutları tekrar kontrol edin; o uygulamanın format dönüşümü onları normalleştirebilir.
- **Dışa aktarma formatları:** Yukarıdaki not ve el ilanı PDF örnekleri yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler tam sayı piksel boyutları ve bir render ölçeği kullanır, bu nedenle kesirli nokta değerleri görüntü çıktısında yuvarlanabilir. Normal slaytların dışa aktarımı not sayfası boyutunu uygulamaz.
- **Yazıcı sürücüleri:** Kağıt seçimi, otomatik döndürme ve sayfaya sığdırma ayarları, sunumda veya PDF’de depolanan boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için, yazıcı ayarlarını eşleştirin ve yazdırma önizlemesini inceleyin.

## **SSS**

**Bir slayt için yalnızca not boyutunu ayarlayabilir miyim?**

Not sayfası boyutu sunum seviyesinde bir ayardır. Tek tek slaytların farklı not içerikleri olabilir, ancak bu özellik her slayt için ayrı bir sayfa boyutu sunmaz.

**Neden not yönünü değiştirmek slaytlarımı etkilemedi?**

Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytların kendisini yeniden boyutlandırmak istediğinizde normal slayt boyutu ayarlarını kullanın.

**Kaydedilen veya yazdırılan sonuç neden farklı bir boyuta sahip?**

Öncelikle kaydedilen sunumu yeniden açın ve not boyutlarını karşılaştırın. Eğer değiştiyse, dosyayı başka bir uygulamada kaydetmenin veya dönüştürmenin sayfa ayarlarını değiştirip değiştirmediğini kontrol edin. Değişmediyse, dışa aktarma düzenini, görüntü ölçeğini, görüntüleyici ayarlarını ve yazıcı kağıt seçimini inceleyin.