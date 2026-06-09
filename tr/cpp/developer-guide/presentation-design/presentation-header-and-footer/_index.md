---
title: C++'ta Sunum Üstbilgi ve Altbilgi Yönetimi
linktitle: Üstbilgi ve Altbilgi
type: docs
weight: 140
url: /tr/cpp/presentation-header-and-footer/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ı kullanarak PowerPoint ve OpenDocument sunumlarına profesyonel bir görünüm kazandırmak için üstbilgi ve altbilgi ekleyin ve özelleştirin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki üstbilgi ve altbilgi ayarlarını yönetmenizi sağlar. Üstbilgi ve altbilgiler sunum ana düzeyinde işlenir ve API, altbilgi metnini ayarlama, altbilgi görünürlüğünü değiştirme ve ana not slaytlarındaki üstbilgi metnini güncelleme yöntemleri sunar.

Not el ilanı ve not slaytları için de üstbilgi ve altbilgileri yönetebilirsiniz. Bu, not ana slaytı, tüm alt not slaytları veya tek bir not slaytı için üstbilgi, altbilgi, slayt numarası ve tarih‑saat yer tutucularının görünürlüğünü ve metnini değiştirmeyi içerir.

## **Üstbilgi ve Altbilgi Metnini Yönetme**

Belirli bir slaydın notları aşağıdaki örnekte gösterildiği gibi güncellenebilir:

``` cpp
// Başlık/Altbilgi Metnini ayarlama işlevi
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Sunumu Yükle
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Altbilgi Ayarlama
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Üstbilgiye Eriş ve Güncelle
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Sunumu Kaydet
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **El İlanı ve Not Slaytlarında Üstbilgi ve Altbilgileri Yönetme**
Aspose.Slides for C++ supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Bir video içeren bir [Sunum](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) yükleyin.
- Not ana slaytı ve tüm not slaytları için üstbilgi ve altbilgi ayarlarını değiştirin.
- Ana not slaytındaki ve tüm alt Footer yer tutucularının görünür olmasını ayarlayın.
- Ana not slaytındaki ve tüm alt Tarih ve saat yer tutucularının görünür olmasını ayarlayın.
- Yalnızca ilk not slaytı için üstbilgi ve altbilgi ayarlarını değiştirin.
- Not slaytındaki üstbilgi yer tutucusunun görünür olmasını ayarlayın.
- Not slaytındaki üstbilgi yer tutucusuna metin ayarlayın.
- Not slaytındaki tarih‑saat yer tutucusuna metin ayarlayın.
- Değiştirilmiş sunum dosyasını yazın.

Code Snippet provided in the below Example.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Not ana slaytı ve tüm not slaytları için Üstbilgi ve Altbilgi ayarlarını değiştir
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// ana not slaytı ve tüm alt Footer yer tutucularını görünür yap
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// ana not slaytı ve tüm alt Header yer tutucularını görünür yap
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// ana not slaytı ve tüm alt SlideNumber yer tutucularını görünür yap
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// ana not slaytı ve tüm alt Tarih ve saat yer tutucularını görünür yap
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// ana not slaytı ve tüm alt Header yer tutucularına metin ayarla
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// ana not slaytı ve tüm alt Footer yer tutucularına metin ayarla
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// ana not slaytı ve tüm alt Tarih ve saat yer tutucularına metin ayarla
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// sadece ilk not slaytı için Üstbilgi ve Altbilgi ayarlarını değiştir
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// bu not slaytı Header yer tutucusunu görünür yap
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// bu not slaytı Footer yer tutucusunu görünür yap
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// bu not slaytı SlideNumber yer tutucusunu görünür yap
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// bu not slaytı Date-time yer tutucusunu görünür yap
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// not slaytı Header yer tutucusuna metin ayarla
	headerFooterManager->SetHeaderText(u"New header text");
	// not slaytı Footer yer tutucusuna metin ayarla
	headerFooterManager->SetFooterText(u"New footer text");
	// not slaytı Date-time yer tutucusuna metin ayarla
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **SSS**

**Normal slaytlara "üstbilgi" ekleyebilir miyim?**

PowerPoint'te "Üstbilgi" yalnızca notlar ve el ilanları için bulunur; normal slaytlarda desteklenen öğeler altbilgi, tarih/saat ve slayt numarasıdır. Aspose.Slides de aynı sınırlamaları uygular: üstbilgi sadece Notlar/El İlanı için vardır ve slaytlarda—Altbilgi/TarihSaat/SlaytNumarası.

**Düzen bir altbilgi alanı içermiyorsa—görünürlüğünü "aç"abilir miyim?**

Evet. Görünürlüğü üstbilgi/altbilgi yöneticisi aracılığıyla kontrol edin ve gerekirse etkinleştirin. Bu API göstergeleri ve yöntemleri, yer tutucu eksik ya da gizli olduğunda kullanılmak üzere tasarlanmıştır.

**Slayt numarasını 1 yerine başka bir değerden nasıl başlatabilirim?**

Sunumun [ilk slayt numarası](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/set_firstslidenumber/) ayarlayın; ardından tüm numaralandırma yeniden hesaplanır. Örneğin, 0 veya 10’dan başlayabilir ve başlık slaytındaki numarayı gizleyebilirsiniz.

**PDF/görüntülere/HTML'ye dışa aktarırken üstbilgi/altbilgi ne olur?**

Sunumun normal metin öğeleri olarak işlenirler. Yani, öğeler slayt/nota sayfalarında görünürse, çıktı formatında da diğer içeriklerle birlikte görüneceklerdir.