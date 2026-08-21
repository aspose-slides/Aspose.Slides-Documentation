---
title: Python'da Sunumlarda Çizim Kılavuzlarını Yönetme
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/python-net/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- dikey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- layout slayt
- not master
- el dağıtım master
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında yatay ve dikey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, PowerPoint'te bir sunumu düzenlerken kullanıcıların şekilleri tutarlı bir şekilde hizalamasına yardımcı olan ayarlanabilir yatay ve dikey çizgilerdir. Uygulama, daha sonra manuel olarak rafine edilecek bir sunum oluşturduğunda özellikle faydalıdır: uygulama, yazarların içerik eklerken veya taşırken takip etmeleri gereken aynı hizalama yardımcılarını kaydedebilir.

Çizim kılavuzları, düzenleme yardımcılarıdır, slayt içeriği değildir. Slayt gösterisinde veya oluşturulan çıktıda görünmezler. Aspose.Slides for Python via .NET, bunları [IDrawingGuidesCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguidescollection/) arayüzü aracılığıyla sunar. Bir kılavuz, [IDrawingGuide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguide/) tarafından temsil edilir ve bir yönelim, bir konum ve bir renge sahiptir.

Konum, ilgili slaytın veya master'ın sol üst köşesinden puan cinsinden ölçülür. Dikey bir kılavuz, genellikle sıfır ile slayt genişliği arasında bir yatay koordinat kullanır. Yatay bir kılavuz, genellikle sıfır ile slayt yüksekliği arasında bir düşey koordinat kullanır.

## **Slayt Görünümüne Kılavuz Ekleme**

Normal slaytları düzenlerken görüntülenen kılavuzları yönetmek için [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) kullanın. [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguidescollection/add/) metodunu bir [Orientation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/orientation/) değeri ve puan cinsinden bir konumla çağırın.

Aşağıdaki örnek, slayt ortasının sağında bir dikey kılavuz ve onun altında bir yatay kılavuz ekler:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizim Kılavuzlarına Erişim**

[IDrawingGuidesCollection.count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguidescollection/count/) özelliği ve indeksleyici mevcut kılavuzlara erişim sağlar. [IDrawingGuide.orientation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguide/position/) ve [IDrawingGuide.color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguide/color/) özellikleri okunabilir veya değiştirilebilir.

Aşağıdaki örnek, yukarıda oluşturulan sunumdan slayt‑görünümü kılavuzlarını okur:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Master ve Layout Slaytlara Kılavuz Ekleme**

Bir slayt master'ı ve onun her layout slaytı, kendi çizim‑kılavuz koleksiyonlarına sahip olabilir. Master slayt için [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/drawing_guides/) ve layout slayt için [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ilayoutslide/drawing_guides/) kullanın.

Aşağıdaki örnek, ilk master slayta bir dikey kılavuz ve ilk layout slayta bir yatay kılavuz ekler:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Not ve El İdaresi Masterlarına Kılavuz Ekleme**

Not master'ları ve el dağıtım master'ları da çizim kılavuzlarını destekler. Koleksiyonlarına erişmek için [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasternotesslide/drawing_guides/) ve [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) kullanın. Sunum bu master'lardan birini içermiyorsa, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) veya [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) varsayılan master'ı oluşturur ve döndürür.

Aşağıdaki örnek, bir not master'ına yatay bir kılavuz ve bir el dağıtım master'ına dikey bir kılavuz ekler:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizim Kılavuzlarını Temizleme**

Belirli bir koleksiyondan tüm kılavuzları kaldırmak için [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/idrawingguidescollection/clear/) metodunu çağırın. Bir koleksiyonun temizlenmesi, başka bir kapsamda depolanan kılavuzları etkilemez.

Aşağıdaki örnek, slayt‑görünümü kılavuzlarını ve slayt master'ları, layout slaytları, not master'ı ve el dağıtım master'ındaki tüm kılavuzları eksik master'lar oluşturulmadan temizler:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Çizim kılavuzları slayt gösterisinde veya dışa aktarılan görsellerde görünür mü?**

Hayır. Çizim kılavuzları, düzenleme için hizalama yardımcılarıdır ve sunum içeriği olarak işlenmez.

**Bir çizim kılavuzu doğrudan bireysel normal slayta eklenebilir mi?**

Normal slayt düzenleme kılavuzları, sunumun slayt‑görünüm özelliklerinde depolanır. Slayt master'ları, layout slaytları, not master'ları ve el dağıtım master'ları için ayrı kılavuz koleksiyonları mevcuttur.

**Kılavuz konumları için hangi birimler kullanılır?**

Konumlar puan cinsinden belirtilir; 72 puan bir inçtir. Dikey konumlar sol kenardan, yatay konumlar üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri veya slayt içeriğini değiştirir mi?**

Hayır. `clear` yöntemi yalnızca seçili koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içeriği değişmeden kalır.