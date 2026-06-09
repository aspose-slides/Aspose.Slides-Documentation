---
title: Yeni HTML Dışa Aktarma Sistemi - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /tr/net/web-extensions/
keywords:
- web uzantısı
- şablon motoru
- PowerPoint dışa aktarımı
- OpenDocument dışa aktarımı
- sunum dışa aktarımı
- slayt dışa aktarımı
- PPT dışa aktarımı
- PPTX dışa aktarımı
- ODP dışa aktarımı
- PowerPoint'ten HTML'ye
- OpenDocument'ten HTML'ye
- sunumdan HTML'ye
- slayttan HTML'ye
- PPT'den HTML'ye
- PPTX'den HTML'ye
- ODP'den HTML'ye
- .NET
- C#
- Aspose.Slides
description: "Şablonlar, CSS ve JS ile sunumları HTML'ye dışa aktar—SVG yok. PPT, PPTX ve ODP için tek veya çok sayfalı çıktı, kaynak kontrolü ve özelleştirme öğrenin."
---
## **Giriş**

* Eski Aspose.Slides API sürümlerinde, PowerPoint'i HTML'ye dışa aktardığınızda, oluşan HTML bir SVG işaretlemesiyle HTML'nin birleştirilmiş hali olarak temsil edildi. Her slayt bir SVG kapsayıcısı olarak dışa aktarıldı. 
* Yeni Aspose.Slides sürümlerinde, PowerPoint sunumlarını HTML'ye dışa aktarmak için WebExtensions sistemini kullandığınızda, en iyi sonuçları elde etmek için HTML dışa aktarma ayarlarını özelleştirebilirsiniz. 

Yeni WebExtensions sistemini kullanarak, bir tüm sunumu CSS sınıfları ve JavaScript animasyonları (SVG olmadan) içeren HTML'ye dışa aktarabilirsiniz. Yeni dışa aktarma sistemi ayrıca dışa aktarma sürecini tanımlayan sınırsız sayıda seçenek ve yöntem sunar. 

Yeni WebExtensions sistemi, aşağıdaki durum ve olaylarda sunumlardan HTML üretmek için kullanılır:

* özel CSS stilleri veya animasyonları kullanırken; belirli şekil türleri için işaretlemeyi geçersiz kıldığınızda.  
* belge yapısını geçersiz kıldığınızda, ör. sayfalar arasında özel gezinme kullandığınızda.
* .html, .css, .js dosyalarını özelleştirilmiş hiyerarşiyle klasörlere kaydederken, belirli dosya türlerini farklı klasörlerde tutmak. Örneğin, slaytları bölüm adına göre bir klasöre dışa aktarmak.
* CSS ve JS dosyalarını varsayılan olarak ayrı klasörlere kaydederken ve ardından bir HTML dosyasına eklerken. Görseller ve gömülü fontlar da ayrı dosyalara kaydedilir. Ancak bunlar HTML dosyasına (base64 biçiminde) gömülebilir. Kaynakların bazı bölümlerini dosyalara kaydedebilir, diğerlerini ise HTML içinde base64 olarak gömebilirsiniz.

PowerPoint'ten HTML'ye örneklerine [Aspose.Slides.WebExtensions projesinde](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) göz atabilirsiniz. Proje 2 bölüm içerir: **Examples\SinglePageApp** ve **Examples\MultiPageApp**. Bu makalede kullanılan diğer örnekler de GitHub deposunda bulunabilir.

### **Şablonlar**

HTML dışa aktarımının yeteneklerini daha da genişletmek için ASP.NET Razor şablon sistemini kullanmanız önerilir. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği, dışa aktarma sonucunda bir HTML belgesi elde etmek için bir dizi şablonla birlikte kullanılabilir.

**Demonstrasyon**

Bu örnekte, bir sunumdan metni HTML'ye dışa aktaracağız. İlk olarak, şablonu oluşturalım:

``` html
<!DOCTYPE html>
<body>
    @foreach (Slide slide in Model.Object.Slides)    
    {
        foreach (Shape shape in slide.Shapes)
        {
            if(shape is AutoShape)
            {
                ITextFrame textFrame = ((AutoShape)shape).TextFrame;
                <div class="text">@textFrame.Text</div>
            }
        }
    }
</body>
</html>
```
Bu şablon, sonraki adımda kullanılacak şekilde diske "shape-template-hello-world.html" adıyla kaydedilir.

Bu şablonda, sunum şekillerindeki metin çerçevelerini döndürerek metni görüntülüyoruz. WebDocument kullanarak HTML dosyasını oluşturalım ve ardından Presentation'ı dosyaya dışa aktaralım: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Razor şablon motorunu kullanmayı amaçlıyoruz. Diğer şablon motorları ITemplateEngine arayüzünü uygulayarak kullanılabilir.  
        OutputSaver = new FileOutputSaver() // Diğer sonuç kaydediciler IOutputSaver arayüzünü uygulayarak kullanılabilir.
    };
    WebDocument document = new WebDocument(options);

    // belge "giriş" ekle - HTML belgesini oluşturmak için kullanılacak kaynak
    document.Input
        .AddTemplate<Presentation>( // şablon, Presentation'ı bir "model" nesnesi (Model.Object) olarak kullanacak 
        "index", // şablon anahtarı - şablon motorunun bir nesneyi (Presentation) diskte yüklü şablonla ("shape-template-hello-world.html") eşleştirmek için gerekir  
        @"custom-templates\shape-template-hello-world.html"); // daha önce oluşturduğumuz şablon
                
    // çıkışı ekle - oluşan HTML belgesinin diske dışa aktarıldığında nasıl görüneceği
    document.Output.Add(
        "hello-world.html", // çıkış dosya yolu
        "index", // bu dosya için kullanılacak şablon anahtarı (önceki satırda ayarladık)  
        pres); // gerçek bir Model.Object örneği 
                
    document.Save();
}
```

Örneğin, dışa aktarma sonucuna metin rengini kırmızıya değiştirecek CSS stilleri eklemek istiyoruz. CSS şablonunu ekleyelim:

``` css
.text {
    color: red;
}
```

Şimdi, bunu girdi ve çıktıya ekleyelim:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hello-world.html", "index", pres); 
    document.Output.Add("hello-world.css", "styles", pres);
                
    document.Save();
}
```

Şablona ve "text" sınıfına stiller referansını ekleyelim:
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Varsayılan Şablonlar**

WebExtensions, sunumları HTML'ye dışa aktarmak için 2 temel şablon seti sağlar:
* Tek sayfa: tüm sunum içeriği tek bir HTML dosyasına dışa aktarılır. Diğer tüm kaynaklar (görseller, fontlar, stiller vb.) ayrı dosyalara dışa aktarılır.
* Çok sayfa: her sunum slaytı ayrı bir HTML dosyasına dışa aktarılır. Kaynakların dışa aktarım mantığı tek sayfadakine benzer. 

`PresentationExtensions` sınıfı, şablonları kullanarak sunum dışa aktarma sürecini basitleştirmek için kullanılabilir. `PresentationExtensions` sınıfı, Presentation sınıfı için bir dizi uzantı yöntemi içerir. Bir sunumu tek sayfaya dışa aktarmak için Aspose.Slides.WebExtensions ad alanını ekleyin ve iki yöntemi çağırın. İlk yöntem olan `ToSinglePageWebDocument`, bir `WebDocument` örneği oluşturur. İkinci yöntem ise HTML belgesini kaydeder: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

`ToSinglePageWebDocument` yöntemi iki parametre alabilir: şablonlar klasörü ve dışa aktarma klasörü. 

Sunumu çok sayfaya dışa aktarmak için aynı parametrelerle `ToMultiPageWebDocument` metodunu kullanın:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

WebExtensions'te, işaretleme oluşturmak için kullanılan her şablon bir anahtara bağlanır. Bu anahtar şablonlarda kullanılabilir. Örneğin, @Include yönergesinde bir şablonu anahtarla başka bir şablona ekleyebilirsiniz.

Paragraf şablonu içinde metin bölümü şablonu kullanımını örnekleyerek prosedürü gösterebiliriz. Örneği Aspose.Slides.WebExtensions projesinde bulabilirsiniz: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Paragraftaki bölümleri çizmek için Razor Engine'in @foreach yönergesini kullanarak döneriz:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Bölümün kendine ait şablonu [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) vardır ve bunun için bir model oluşturulur. Bu model çıkış paragraph.html şablonuna eklenir:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Her şekil türü için, Aspose.Slides.WebExtensions projesinin genel şablon setine eklenen özelleştirilmiş bir şablon kullanırız. Şablonlar `ToSinglePageWebDocument` ve `ToMultiPageWebDocument` yöntemlerinde birleştirilerek nihai sonuç elde edilir. Bunlar tek ve çok sayfalı çıktılarda kullanılan ortak şablonlardır:

- templates
+-common
  ¦ +-scripts: slide geçiş animasyonları için javascript betikleri, örnek olarak.
  ¦ +-styles: ortak CSS stilleri.
  +-multi-page: çok sayfalı çıktı için index, menü, slayt şablonları.
  +-single-page: tek sayfalı çıktı için index, slayt şablonları.

Tüm şablonlar için ortak bölümün nasıl bağlandığını `PresentationExtensions.AddCommonInputOutput` yönteminde [burada](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs) bulabilirsiniz.

### **Varsayılan Şablon Özelleştirme**

Ortak model şablonundaki herhangi bir öğeyi değiştirebilirsiniz. Örneğin, tablo biçimlendirme stillerini değiştirip tek sayfanın diğer stillerinin aynı kalmasını isteyebilirsiniz.

Varsayılan olarak Templates\common\table.html kullanılır ve tablo, PowerPoint'teki tabloyla aynı görünüme sahiptir. Özel CSS stilleriyle tablo biçimlendirmesini değiştirelim:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

`PresentationExtensions.ToSinglePageWebDocument` yöntemini çağırırken aynı giriş şablonları ve çıkış dosyaları yapısını oluşturabiliriz. Bunun için `ExportCustomTableStyles_AddCommonStructure` yöntemini ekleyelim. Bu yöntem ile `ToSinglePageWebDocument` yöntemi arasındaki fark — tablo ve ana index sayfası için standart şablonu eklememize gerek yok (özelleştirilmiş tablo stillerine referans eklenerek değiştirilecektir):

``` csharp
private static void ExportCustomTableStyles_AddCommonStructure(
    Presentation pres, 
    WebDocument document,
    string templatesPath, 
    string outputPath, 
    bool embedImages)
{
    AddCommonStylesTemplates(document, templatesPath);
            
    document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
    document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
    document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
    document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
    document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
    document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));
    document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));
    document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
    document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

    AddSinglePageCommonOutput(pres, document, outputPath);
            
    AddResourcesOutput(pres, document, embedImages);
            
    AddScriptsOutput(document, templatesPath);
}
```

Bunun yerine özelleştirilmiş bir şablon ekleyelim:

``` csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "custom-table-styles";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // global belge değerlerini ayarla
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // ortak yapıyı ekle (tablo şablonu hariç)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // özel tablo şablonunu ekle
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // özel tablo stillerini ekle
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // özel indeks ekle - sadece standart "index.html" dosyasının bir kopyasıdır, ancak "table-custom-style.css" dosyasına referans içerir
    document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
    document.Save();
}
```

``` html
@model TemplateContext<Table>

@{
	Table contextObject = Model.Object;
	
	var origin = Model.Local.Get<Point>("origin");
	var positionStyle = string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;",
										(int)contextObject.X + origin.X,
										(int)contextObject.Y + origin.Y,
										(int)contextObject.Width,
										(int)contextObject.Height);
}

	<table class="table custom-table" style="@positionStyle">
	@for (int i = 0; i < contextObject.Rows.Count; i++)
	{
		var rowHeight = string.Format("height: {0}px", contextObject.Rows[i].Height);
		<tr style="@rowHeight">
		@for (int j = 0; j < contextObject.Columns.Count; j++)
		{
			var cell = contextObject[j, i];
			if (cell.FirstRowIndex ==  i && cell.FirstColumnIndex == j)
			{
				var spans = cell.IsMergedCell ? string.Format("rowspan=\"{0}\" colspan=\"{1}\"", cell.RowSpan, cell.ColSpan) : "";
				<td width="@cell.Width px" @Raw(spans)>
					@{
						for(int k = 0; k < cell.TextFrame.Paragraphs.Count; k++)
						{
							var para = (Paragraph)cell.TextFrame.Paragraphs[k];
						
							var subModel = Model.SubModel(para);
							double[] margins = new double[] { cell.MarginLeft, cell.MarginTop, cell.MarginRight, cell.MarginBottom };
							subModel.Local.Put("margins", margins);
							subModel.Local.Put("parent", cell.TextFrame);
							subModel.Local.Put("parentContainerSize", new SizeF((float)cell.Width, (float)cell.Height));
                            subModel.Local.Put("tableContent", true);
							
							@Include("paragraph", subModel)
						}
					}
				</td>
			}
		}
		</tr>
	}
</table>
```

**Not**: Özelleştirilmiş tablo şablonu, standart tabloyla aynı “table” anahtarı ile eklendi. Böylece belirli bir varsayılan şablonu yeniden yazmadan değiştirebilirsiniz. Aynı anahtarları kullanan varsayılan yapıdan da şablonları kullanabilirsiniz. Örneğin, tablo şablonunda standart paragraf şablonunu kullanabilir veya anahtarıyla değiştirebilirsiniz.

Ayrıca, `index.html` içinde özelleştirilmiş tablo CSS stillerine referansı ekleyebilirsiniz: 

``` html
<!DOCTYPE html>    
    
<html     
    xmlns="http://www.w3.org/1999/xhtml"    
    xmlns:svg="http://www.w3.org/2000/svg"    
    xmlns:xlink="http://www.w3.org/1999/xlink">    
<head>    
     ...
    <link rel="stylesheet" type="text/css" href="table-custom-style.css" />
    ...
</head>    
<body>    
    ...
</body>
</html>
```

## **Sıfırdan Proje Oluşturma: Hareketli Slayt Geçişleri**

WebExtensions, animasyonlu slayt geçişleriyle sunumları dışa aktarmanıza izin verir—`WebDocumentOptions` içinde `AnimateTransitions` özelliğini `true` olarak ayarlamanız yeterlidir:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... diğer seçenekler
    AnimateTransitions = true
};
```

PDF için sorunsuz animasyonlu sayfa geçişleriyle HTML görüntüleyici oluşturmak amacıyla Aspose.Slides ve Aspose.Slides.WebExtensions kullanan yeni bir proje oluşturalım. Burada Aspose.Slides'in PDF içe aktarma özelliğini kullanmamız gerekiyor.

PdfToPresentationToHtml projesini oluşturalım ve Aspose.Slides.WebExtensions NuGet paketini ekleyelim (Aspose.Slides paketi de bağımlılık olarak eklenecektir):
![NuGet Paketi](screen.png)

PDF belgesini içe aktarmayla başlıyoruz; bu belge animasyonlu olacak ve bir HTML sunumuna dışa aktarılacak:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Şimdi, animasyonlu slayt geçişlerini ayarlayabiliriz (her slayt içe aktarılan PDF sayfasıdır). Örnek PDF belgesinde 9 slayt kullandık. Her birine slayt geçişi ekleyelim (HTML görüntülerken gösterim):

``` csharp
pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;
```

Son olarak, `AnimateTransitions` özelliği `true` olarak ayarlanmış `WebDocument` kullanarak HTML'ye dışa aktaralım:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
document.Save();
```

Tam kaynak kodu örneği:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
    pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
    pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
    pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
    pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
    pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
    pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
    pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;

    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        AnimateTransitions = true
    };

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
    document.Save();
}
```

PDF belgesinden oluşturulan animasyonlu sayfa geçişli HTML oluşturmak için ihtiyacınız olan tek şey bu.

* [Örnek HTML dosyasını indirin](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Örnek projeyi indirin](/slides/tr/net/web-extensions/sample.zip).