---
title: .NET'te Sunumlarda Çizim Kılavuzlarını Yönetme
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/net/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- dikey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- düzen slaytı
- not master
- el kitabı master
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında yatay ve dikey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, PowerPoint'te bir sunumu düzenlerken kullanıcıların şekilleri tutarlı bir şekilde hizalamasına yardımcı olan ayarlanabilir yatay ve dikey çizgilerdir. Özellikle bir uygulama bir sunumu otomatik olarak oluşturup daha sonra manuel olarak düzenlenecekse faydalıdır: uygulama, yazarların içerik eklerken veya hareket ettirirken takip etmesi gereken aynı hizalama yardımcılarını kaydedebilir.

Çizim kılavuzları düzenleme yardımcılarıdır, slayt içeriği değildir. Slayt gösterisi veya oluşturulmuş çıktıda görünmezler. Aspose.Slides for .NET, bunları [IDrawingGuidesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguidescollection/) arayüzü aracılığıyla sunar. Bir kılavuz, [IDrawingGuide](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguide/) ile temsil edilir ve bir yönlendirme, bir konum ve bir renge sahiptir.

Konum, ilgili slayt veya master’ın sol üst köşesinden itibaren puan cinsinden ölçülür. Dikey bir kılavuz, genellikle sıfır ile slayt genişliği arasında bir yatay koordinat kullanır. Yatay bir kılavuz, genellikle sıfır ile slayt yüksekliği arasında bir düşey koordinat kullanır.

## **Kılavuzları Slayt Görünümüne Ekle**

Normal slaytları düzenlerken gösterilen kılavuzları yönetmek için [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/tr/net/aspose.slides/icommonslideviewproperties/drawingguides/) kullanın. Bir [Orientation](https://reference.aspose.com/slides/tr/net/aspose.slides/orientation/) değeri ve puan cinsinden bir konumla [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguidescollection/add/) çağırın.

Aşağıdaki örnek, slayt ortasının sağ tarafına bir dikey kılavuz ve altında bir yatay kılavuz ekler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Çizim Kılavuzlarına Erişim**

[IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguidescollection/count/) özelliği ve indeksleyici, mevcut kılavuzlara erişim sağlar. [IDrawingGuide.Orientation](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguide/position/) ve [IDrawingGuide.Color](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguide/color/) özellikleri okunabilir veya değiştirilebilir.

Aşağıdaki örnek, yukarıda oluşturulan sunumdan slayt‑görünümü kılavuzlarını okur:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Kılavuzları Master ve Düzen Slaytlarına Ekle**

Bir slayt master’ı ve onun her bir düzen slaytı, kendi çizim‑kılavuz koleksiyonlarına sahip olabilir. Master slayt için [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/drawingguides/), düzen slaytı için ise [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/drawingguides/) kullanın.

Aşağıdaki örnek, ilk master slayta bir dikey kılavuz ve ilk düzen slayta bir yatay kılavuz ekler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Not ve El Kitabı Master’larına Kılavuz Ekle**

Not master’ları ve el kitabı master’ları da çizim kılavuzlarını destekler. Koleksiyonlarına erişmek için [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslide/drawingguides/) ve [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterhandoutslide/drawingguides/) kullanın. Bir sunum bu master’lardan birini içermiyorsa, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) veya [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) varsayılan master’ı oluşturur ve döndürür.

Aşağıdaki örnek, bir not master’ına bir yatay kılavuz ve bir el kitabı master’ına bir dikey kılavuz ekler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Çizim Kılavuzlarını Temizle**

Belirli bir koleksiyondaki tüm kılavuzları kaldırmak için [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/idrawingguidescollection/clear/) çağırın. Bir koleksiyonun temizlenmesi, başka bir kapsamda saklanan kılavuzları etkilemez.

Aşağıdaki örnek, eksik master’ları oluşturmadan slayt‑görünümü kılavuzlarını ve slayt master’ları, düzen slaytları, not master’ı ve el kitabı master’ındaki tüm kılavuzları temizler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **SSS**

**Çizim kılavuzları slayt gösterisi veya dışa aktarılan görsellerde görünür mü?**

Hayır. Çizim kılavuzları düzenleme için hizalama yardımcılarıdır ve sunum içeriği olarak işlenmez.

**Bir çizim kılavuzu doğrudan tek bir normal slayta eklenebilir mi?**

Normal slayt düzenleme kılavuzları, sunumun slayt‑görünümü özelliklerinde saklanır. Slayt master’ları, düzen slaytları, not master’ları ve el kitabı master’ları için ayrı kılavuz koleksiyonları bulunur.

**Kılavuz konumları için hangi birimler kullanılır?**

Konumlar puan cinsinden belirtilir; 72 puan bir inçe eşittir. Dikey konumlar sol kenardan, yatay konumlar üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri kaldırır veya slayt içeriğini değiştirir mi?**

Hayır. `Clear` yöntemi yalnızca seçilen koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içeriği değişmeden kalır.