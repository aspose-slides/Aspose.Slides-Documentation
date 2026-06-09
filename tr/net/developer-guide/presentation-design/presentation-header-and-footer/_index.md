---
title: .NET'te Sunum Üstbilgi ve Altbilgi Yönetimi
linktitle: Üstbilgi ve Altbilgi
type: docs
weight: 140
url: /tr/net/presentation-header-and-footer/
keywords:
- üstbilgi
- üstbilgi metni
- altbilgi
- altbilgi metni
- üstbilgi ayarla
- altbilgi ayarla
- el ilanı
- notlar
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i kullanarak PowerPoint ve OpenDocument sunumlarında profesyonel bir görünüm elde etmek için üstbilgi ve altbilgi ekleyin ve özelleştirin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında üstbilgi ve altbilgi ayarlarını yönetmenizi sağlar. Üstbilgi ve altbilgi sunum ana düzeyinde işlenir ve API, altbilgi metnini ayarlama, altbilgi görünürlüğünü değiştirme ve ana not slaytlarındaki üstbilgi metnini güncelleme yöntemleri sunar.

Ayrıca el ilanı ve not slaytları için üstbilgi ve altbilgi yönetebilirsiniz. Bu, not ana slaytı, tüm alt not slaytları veya tek bir not slaytı için üstbilgi, altbilgi, slayt numarası ve tarih‑saat yer tutucularının görünürlüğünü ve metnini değiştirmeyi içerir.

## **Üstbilgi ve Altbilgi Metnini Yönet**

Belirli bir slaydın notları, aşağıdaki örnekte gösterildiği gibi güncellenebilir:

```c#
// Sunumu Yükle
Presentation pres = new Presentation("headerTest.pptx");

// Altbilgi Ayarlama
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Üstbilgiye Eriş ve Güncelle
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Sunumu Kaydet
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Üstbilgi/Altbilgi Metnini Ayarlama Yöntemi
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```

## **El İlanı ve Not Slaytlarında Üstbilgi ve Altbilgi Yönet**

Aspose.Slides for .NET, el ilanı ve not slaytlarında Üstbilgi ve Altbilgi'yi destekler. Lütfen aşağıdaki adımları izleyin:

- Load a [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)containing a video.
- Not ana slaytı ve tüm not slaytları için Üstbilgi ve Altbilgi ayarlarını değiştirin.
- Ana not slaytı ve tüm altbilgi yer tutucularını görünür yapın.
- Ana not slaytı ve tüm tarih ve saat yer tutucularını görünür yapın.
- Yalnızca ilk not slaytı için Üstbilgi ve Altbilgi ayarlarını değiştirin.
- Not slaytı Üstbilgi yer tutucusunu görünür yapın.
- Not slaytı Üstbilgi yer tutucusuna metin ayarlayın.
- Not slaytı Tarih‑saat yer tutucusuna metin ayarlayın.
- Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte kod parçacığı sağlanmıştır.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Not ana slaytı ve tüm not slaytları için Üstbilgi ve Altbilgi ayarlarını değiştir
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // ana not slaytını ve tüm alt Footer yer tutucularını görünür yap
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // ana not slaytını ve tüm alt Header yer tutucularını görünür yap
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // ana not slaytını ve tüm alt SlideNumber yer tutucularını görünür yap
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // ana not slaytını ve tüm alt tarih ve saat yer tutucularını görünür yap

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // ana not slaytına ve tüm alt Header yer tutucularına metin ayarla
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // ana not slaytına ve tüm alt Footer yer tutucularına metin ayarla
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // ana not slaytına ve tüm alt tarih ve saat yer tutucularına metin ayarla
	}

	// Yalnızca ilk not slaytı için Üstbilgi ve Altbilgi ayarlarını değiştir
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // bu not slaytının Header yer tutucusunu görünür yap

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // bu not slaytının Footer yer tutucusunu görünür yap

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // bu not slaytının SlideNumber yer tutucusunu görünür yap

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // bu not slaytının Date-time (tarih-saat) yer tutucusunu görünür yap

		headerFooterManager.SetHeaderText("New header text"); // not slaytı Header yer tutucusuna metin ayarla
		headerFooterManager.SetFooterText("New footer text"); // not slaytı Footer yer tutucusuna metin ayarla
		headerFooterManager.SetDateTimeText("New date and time text"); // not slaytı Date-time (tarih-saat) yer tutucusuna metin ayarla
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **SSS**

**Normal slaytlara bir "üstbilgi" ekleyebilir miyim?**

PowerPoint'te "Üstbilgi" sadece notlar ve el ilanları için bulunur; normal slaytlarda desteklenen öğeler altbilgi, tarih/saat ve slayt numarasıdır. Aspose.Slides'te de aynı sınırlamalar geçerlidir: üstbilgi yalnızca Notlar/El İlanı için, slaytlarda ise Altbilgi/TarihSaat/SlaytNumarası.

**Düzen bir altbilgi alanı içermiyorsa—görünürlüğünü "açabilir" miyim?**

Evet. Görünürlüğü üstbilgi/altbilgi yöneticisi üzerinden kontrol edin ve gerekirse etkinleştirin. Bu API göstergeleri ve yöntemleri, yer tutucu eksik veya gizli olduğunda kullanılmak üzere tasarlanmıştır.

**Slayt numarasını 1 dışında bir değerden başlatmak nasıl yapılır?**

Sunumun [first slide number](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/firstslidenumber/) özelliğini ayarlayın; ardından tüm numaralandırma yeniden hesaplanır. Örneğin, 0 veya 10'dan başlayabilir ve başlık slaytındaki numarayı gizleyebilirsiniz.

**PDF/görüntüler/HTML olarak dışa aktarırken üstbilgi/altbilgi ne olur?**

Sunumun normal metin öğeleri olarak işlenirler. Yani, öğeler slaytlar/not sayfalarında görünürse, çıktı formatında da diğer içeriklerle birlikte görüntülenir.