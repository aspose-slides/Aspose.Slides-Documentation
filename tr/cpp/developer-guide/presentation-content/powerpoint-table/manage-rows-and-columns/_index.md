---
title: PowerPoint Tablolarında Satır ve Sütunları C++ ile Yönetme
linktitle: Satırlar ve Sütunlar
type: docs
weight: 20
url: /tr/cpp/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satırı klonla
- sütunu klonla
- satırı kopyala
- sütunu kopyala
- satırı kaldır
- sütunu kaldır
- satır metin biçimlendirmesi
- sütun metin biçimlendirmesi
- tablo stili
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint'te tablo satırlarını ve sütunlarını yönetin ve sunum düzenlemelerini ve veri güncellemelerini hızlandırın."
---
## **Giriş**

PowerPoint sunumunda bir tablonun satırlarını ve sütunlarını yönetebilmeniz için, Aspose.Slides [Table](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) arayüzünü ve birçok başka türü sağlar. 

## **İlk Satırı Başlık Olarak Ayarlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin. 
2. Slaytın referansını dizini aracılığıyla alın. 
3. Bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi oluşturun ve onu null olarak ayarlayın. 
4. İlgili tabloyu bulmak için tüm [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesneleri üzerinde döngü yapın. 
5. Tablonun ilk satırını başlık olarak ayarlayın. 

Bu C++ kodu, bir tablonun ilk satırını başlık olarak nasıl ayarlayacağınızı gösterir:

```c++
// Presentation sınıfını örnekler 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// null TableEx'i başlatır
SharedPtr<ITable> tbl;

// Şekiller üzerinde döner ve tabloya bir referans ayarlar
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Bir tablonun ilk satırını başlık olarak ayarlar 
tbl->set_FirstRow(true);
```


## **Bir Tablo Satırını veya Sütununu Kopyalama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Slaytın referansını dizini aracılığıyla alın. 
3. `columnWidth` dizisini tanımlayın. 
4. `rowHeight` dizisini tanımlayın. 
5. [AddTable()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addtable/) yöntemiyle slayda bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi ekleyin. 
6. Tablo satırını kopyalayın. 
7. Tablo sütununu kopyalayın. 
8. Değiştirilmiş sunumu kaydedin. 

Bu C++ kodu, bir PowerPoint tablosunun satırını veya sütununu nasıl kopyalayacağınızı gösterir:

```c++
 // Belgeler dizinine yol.
const String outPath = u"../out/CloningInTable_out.pptx";

// Presentation sınıfını örnekler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Slayta bir tablo şekli ekler
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Her hücre için kenar biçimini ayarlar
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone tablo sonuna bir satır ekler
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone tablo içinde belirli bir konuma satır ekler
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone tablo sonuna bir sütun ekler
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone tablo içinde belirli bir konuma sütun ekler
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Sunumu diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```


## **Tablodan Bir Satır veya Sütun Kaldırma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Slaytın referansını dizini aracılığıyla alın. 
3. `columnWidth` dizisini tanımlayın. 
4. `rowHeight` dizisini tanımlayın. 
5. [AddTable()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addtable/) yöntemiyle slayda bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi ekleyin. 
6. Tablo satırını kaldırın. 
7. Tablo sütununu kaldırın. 
8. Değiştirilmiş sunumu kaydedin. 

Bu C++ kodu, bir tablodan satır veya sütun nasıl kaldırılacağını gösterir:

```c++
// Belgeler dizinine yol.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Presentation sınıfını örnekler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Sütunları genişlikleri ve satırları yükseklikleri ile tanımlar
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Slayta bir tablo şekli ekler
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Hücreleri (1, 1) x (2, 1) birleştirir
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hücreleri (1, 2) x (2, 2) birleştirir
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Sunumu diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Tablo Satırı Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Slaytın referansını dizini aracılığıyla alın. 
3. Slayttan ilgili [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesine erişin. 
4. İlk satır hücrelerinin [set_FontHeight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_fontheight/) metodunu ayarlayın. 
5. İlk satır hücrelerinin [set_Alignment()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_alignment/) ve [set_MarginRight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginright/) metodlarını ayarlayın. 
6. İkinci satır hücrelerinin [set_TextVerticalType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframeformat/set_textverticaltype/) metodunu ayarlayın. 
7. Değiştirilmiş sunumu kaydedin. 

Bu C++ kodu işlemi gösterir.

```c++
// Presentation sınıfının bir örneğini oluşturur
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
// İlk satır hücrelerinin yazı tipi yüksekliğini ayarlar
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// İlk satır hücrelerinin metin hizalamasını ve sağ kenar boşluğunu ayarlar
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// İkinci satır hücrelerinin metin dikey tipini ayarlar
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Sunumu diske kaydeder
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Slaytın referansını dizini aracılığıyla alın. 
3. Slayttan ilgili [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesine erişin. 
4. İlk sütun hücrelerinin [set_FontHeight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_fontheight/) metodunu ayarlayın. 
5. İlk sütun hücrelerinin [set_Alignment()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_alignment/) ve [set_MarginRight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginright/) metodlarını ayarlayın. 
6. İkinci sütun hücrelerinin [set_TextVerticalType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframeformat/set_textverticaltype/) metodunu ayarlayın. 
7. Değiştirilmiş sunumu kaydedin. 

Bu C++ kodu işlemi gösterir: 

```c++
// Presentation sınıfının bir örneğini oluşturur
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım

// İlk sütun hücrelerinin yazı tipi yüksekliğini ayarlar
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// İlk sütun hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıda ayarlar
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// İkinci sütun hücrelerinin metin dikey tipini ayarlar
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Tablo Stil Özelliklerini Alma**

Aspose.Slides, bir tablo için stil özelliklerini almanıza olanak tanır, böylece bu ayrıntıları başka bir tabloya veya başka bir yere uygulayabilirsiniz. Bu C++ kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **SSS**

**Varolan bir tabloya PowerPoint tema/ stillerini uygulayabilir miyim?**

Evet. Tablo, slayt/düzen/ana tema (master) teması miras alır ve bu temanın üzerine dolgu, kenarlık ve metin renklerini hâlâ geçersiz kılabilirsiniz.

**Tablo satırlarını Excel'deki gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tablolarının yerleşik sıralama veya filtreleme özelliği yoktur. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını bu sırayla yeniden doldurun.

**Belirli hücrelerde özel renkleri korurken çizgili (stripe) sütunlar elde edebilir miyim?**

Evet. Çizgili sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre düzeyindeki biçimlendirme tablo stiline göre önceliklidir.