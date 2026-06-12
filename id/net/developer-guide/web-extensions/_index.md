---
title: Sistem Ekspor HTML Baru - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /id/net/web-extensions/
keywords:
- ekstensi web
- mesin templat
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- ekspor slide
- ekspor PPT
- ekspor PPTX
- ekspor ODP
- PowerPoint ke HTML
- OpenDocument ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- ODP ke HTML
- .NET
- C#
- Aspose.Slides
description: "Ekspor presentasi ke HTML dengan templat, CSS, dan JS—tanpa SVG. Pelajari output satu halaman atau multi halaman, kontrol sumber daya, dan kustomisasi untuk PPT, PPTX, dan ODP."
---
## **Pendahuluan**

* Pada versi lama API Aspose.Slides, ketika Anda mengekspor PowerPoint ke HTML, HTML yang dihasilkan direpresentasikan sebagai markup SVG yang digabungkan dengan HTML. Setiap slide diekspor sebagai kontainer SVG.  
* Pada versi baru Aspose.Slides, ketika Anda menggunakan sistem WebExtensions untuk mengekspor presentasi PowerPoint ke HTML, Anda dapat menyesuaikan pengaturan ekspor HTML untuk memperoleh hasil terbaik.  

Dengan menggunakan sistem WebExtensions baru, Anda dapat mengekspor seluruh presentasi ke HTML dengan sekumpulan kelas CSS dan animasi JavaScript (tanpa SVG). Sistem ekspor baru juga menyediakan jumlah tak terbatas opsi dan metode yang mendefinisikan proses ekspor.  

Sistem WebExtensions baru digunakan untuk menghasilkan HTML dari presentasi dalam kasus dan situasi berikut:

* ketika menggunakan gaya CSS atau animasi khusus; menimpa markup untuk tipe shape tertentu.  
* ketika menimpa struktur dokumen, misalnya dengan navigasi khusus antar halaman.  
* ketika menyimpan file .html, .css, .js ke dalam folder dengan hierarki yang disesuaikan, termasuk tipe file tertentu di folder yang berbeda. Contohnya, mengekspor slide ke folder berdasarkan nama bagian.  
* ketika menyimpan file CSS dan JS ke dalam folder terpisah secara default dan kemudian menambahkannya ke file HTML. Gambar dan font yang disematkan juga disimpan ke dalam file terpisah. Namun, mereka dapat disematkan dalam file HTML (dalam format base64). Anda dapat menyimpan sebagian sumber daya ke file dan menyematkan sumber daya lain ke HTML sebagai base64.  

Anda dapat melihat contoh konversi PowerPoint ke HTML di [proyek Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) di GitHub. Proyek ini berisi 2 bagian: **Examples\SinglePageApp** dan **Examples\MultiPageApp**. Contoh lain yang digunakan dalam artikel ini juga dapat ditemukan di repositori GitHub.  

### **Templat**

Untuk memperluas kemampuan ekspor HTML lebih jauh, kami merekomendasikan Anda menggunakan sistem templat ASP.NET Razor. Instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dapat digunakan bersama sekumpulan templat untuk menghasilkan dokumen HTML sebagai hasil ekspor.  

**Demonstrasi**

Pada contoh ini, kami akan mengekspor teks dari presentasi ke HTML. Pertama, buat templatnya:

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
Templat ini disimpan di disk dengan nama "shape-template-hello-world.html", yang akan digunakan pada langkah berikutnya.  

Dalam templat ini, kami mengiterasi frame teks pada shape presentasi untuk menampilkan teks. Mari hasilkan file HTML menggunakan WebDocument dan kemudian mengekspor Presentation ke file tersebut: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Kami berniat menggunakan mesin templat Razor. Mesin templat lain dapat digunakan dengan mengimplementasikan ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Penyimpan hasil lain dapat digunakan dengan mengimplementasikan antarmuka IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // tambahkan dokumen "input" - sumber apa yang akan digunakan untuk menghasilkan dokumen HTML
    document.Input
        .AddTemplate<Presentation>( // templat akan memiliki Presentation sebagai objek "model" (Model.Object) 
        "index", // kunci templat - diperlukan oleh mesin templat untuk mencocokkan objek (Presentation) dengan templat yang dimuat dari disk ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // templat yang kami buat sebelumnya
                
    // tambahkan output - bagaimana dokumen HTML yang dihasilkan akan terlihat saat diekspor ke disk
    document.Output.Add(
        "hello-world.html", // jalur file output
        "index", // kunci templat yang akan digunakan untuk file ini (kami menetapkannya pada pernyataan sebelumnya)  
        pres); // sebuah instance Model.Object yang sebenarnya 
                
    document.Save();
}
```

Sebagai contoh, kami ingin menambahkan gaya CSS ke hasil ekspor untuk mengubah warna teks menjadi merah. Tambahkan templat CSS berikut:

``` css
.text {
    color: red;
}
```

Sekarang, masukkan ke dalam input dan output:

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

Tambahkan referensi ke gaya pada templat dan kelas "text":

``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Templat Bawaan**

WebExtensions menyediakan 2 set templat dasar untuk mengekspor presentasi ke HTML:
* **Single-page**: semua konten presentasi diekspor ke satu file HTML. Semua sumber daya lain (gambar, font, gaya, dll.) diekspor ke file terpisah.  
* **Multi-page**: setiap slide presentasi diekspor ke file HTML terpisah. Logika default untuk mengekspor sumber daya sama seperti pada single page.  

Kelas `PresentationExtensions` dapat digunakan untuk menyederhanakan proses ekspor presentasi menggunakan templat. Kelas `PresentationExtensions` berisi sekumpulan metode ekstensi untuk kelas Presentation. Untuk mengekspor presentasi ke halaman tunggal, cukup sertakan namespace Aspose.Slides.WebExtensions dan panggil dua metode. Metode pertama, `ToSinglePageWebDocument`, membuat instance `WebDocument`. Metode kedua menyimpan dokumen HTML:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

Metode `ToSinglePageWebDocument` dapat menerima dua parameter: folder templat dan folder ekspor.  

Untuk mengekspor presentasi ke multi page, gunakan metode `ToMultiPageWebDocument` dengan parameter yang sama:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

Di WebExtensions, setiap templat yang digunakan untuk menghasilkan markup diikat ke sebuah kunci. Kunci tersebut dapat digunakan di dalam templat. Misalnya, pada direktif @Include, Anda dapat menyisipkan templat tertentu ke templat lain melalui kunci tersebut.  

Kami dapat mendemonstrasikan prosedur ini pada contoh penggunaan templat bagian teks di dalam templat paragraf. Contoh dapat ditemukan di proyek Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Untuk menampilkan bagian-bagian dalam paragraf, kami mengiterasinya menggunakan direktif @foreach dari Razor Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Bagian memiliki templatnya sendiri [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) dan model dihasilkan untuknya. Model tersebut akan ditambahkan ke templat output paragraph.html:

``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Untuk setiap tipe shape, kami menggunakan templat khusus, yang ditambahkan ke set templat umum dari proyek Aspose.Slides.WebExtensions. Templat digabungkan dalam metode `ToSinglePageWebDocument` dan `ToMultiPageWebDocument` untuk menghasilkan hasil akhir. Berikut templat umum yang digunakan pada single dan multi-page:

- templates  
+-common  
  ¦ +-scripts: skrip JavaScript untuk animasi transisi slide, sebagai contoh.  
  ¦ +-styles: gaya CSS umum.  
  +-multi-page: index, menu, templat slide untuk output multi-page.  
  +-single-page: index, templat slide untuk output single-page.  

Anda dapat mempelajari bagaimana bagian umum diikat ke semua templat dalam metode `PresentationExtensions.AddCommonInputOutput` [di sini](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).  

### **Kustomisasi Templat Bawaan**

Anda dapat memodifikasi elemen apa pun dalam templat model umum. Misalnya, Anda ingin mengubah gaya pemformatan tabel tetapi tetap menjaga semua gaya lain pada halaman tunggal tetap tidak berubah.  

Secara default, `Templates\common\table.html` digunakan, dan tabel memiliki tampilan yang sama dengan tabel di PowerPoint. Mari ubah pemformatan tabel menggunakan gaya CSS khusus:

``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Kami dapat membuat struktur templat input dan file output yang sama (seperti yang dihasilkan) sambil memanggil metode `PresentationExtensions.ToSinglePageWebDocument`. Tambahkan metode `ExportCustomTableStyles_AddCommonStructure` untuk itu. Perbedaan antara metode ini dan `ToSinglePageWebDocument`—kami tidak perlu menambahkan templat standar untuk tabel dan halaman indeks utama (akan diganti untuk menyertakan referensi ke gaya tabel khusus):

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

Tambahkan templat khusus sebagai gantinya:

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

    // menyiapkan nilai dokumen global
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // menambahkan struktur umum (kecuali templat tabel)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // menambahkan templat tabel khusus
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // menambahkan gaya tabel khusus
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // menambahkan indeks khusus - ini hanya salinan dari "index.html" standar, tetapi menyertakan referensi ke "table-custom-style.css"
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

**Catatan** bahwa templat tabel khusus ditambahkan dengan kunci “table” yang sama seperti tabel standar. Dengan begitu, Anda dapat mengganti templat default tertentu tanpa menulis ulang. Anda juga dapat menggunakan templat dari struktur bawaan dengan kunci yang sama. Misalnya, Anda dapat menggunakan templat paragraf standar dalam templat tabel; Anda juga dapat menggantinya dengan kunci tersebut.  

Anda juga dapat menggunakan `index.html` untuk menyertakan referensi ke gaya CSS tabel khusus di dalamnya:

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

## **Buat Proyek dari Awal: Transisi Slide Animasi**

WebExtensions memungkinkan Anda mengekspor presentasi dengan transisi slide animasi—Anda hanya perlu mengatur properti `AnimateTransitions` pada `WebDocumentOptions` ke `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... opsi lain
    AnimateTransitions = true
};
```

Mari buat proyek baru yang menggunakan Aspose.Slides dan Aspose.Slides.WebExtensions untuk membuat penampil HTML untuk PDF dengan transisi halaman animasi yang halus. Di sini, kita perlu menggunakan fitur impor PDF dari Aspose.Slides.  

Buat proyek `PdfToPresentationToHtml` dan tambahkan paket NuGet Aspose.Slides.WebExtensions (paket Aspose.Slides juga akan ditambahkan sebagai dependensi):
![NuGet Package](screen.png)

Kita mulai dengan mengimpor dokumen PDF, yang akan dianimasikan dan diekspor ke presentasi HTML:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Sekarang, kita dapat mengatur transisi slide animasi (setiap slide adalah halaman PDF yang diimpor). Contoh PDF memiliki 9 slide. Tambahkan transisi slide ke masing‑masingnya (demonstrasi saat melihat HTML):

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

Akhirnya, ekspor ke HTML menggunakan `WebDocument` dengan properti `AnimateTransitions` diatur ke `true`:

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

Contoh kode sumber lengkap:
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

Itulah semua yang Anda perlukan untuk membuat HTML dengan transisi halaman animasi yang dihasilkan dari dokumen PDF.  

* [Unduh file HTML contoh](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).  
* [Unduh proyek contoh](/slides/id/net/web-extensions/sample.zip).