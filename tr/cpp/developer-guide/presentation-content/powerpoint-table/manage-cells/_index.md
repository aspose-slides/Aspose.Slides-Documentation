---
title: C++ Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/cpp/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint'te tablo hücrelerini sorunsuz bir şekilde yönetin. Hücrelere erişim, değiştirme ve stil verme konularında hızlı bir şekilde ustalaşarak slayt otomasyonunu kesintisiz hale getirin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirdikten veya ayırdıktan sonra numaralandırmayı, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunum oluşturma veya açma, bir slayttan tablo alma, hücre özellikleri aracılığıyla hücre biçimlendirmesini güncelleme ve değiştirilen sunumu PPTX dosyası olarak kaydetme adımlarını gösterir.

## **Birleştirilmiş Hücreyi Belirleme**
1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. İlk slayttan tabloyu alın.  
3. Birleştirilmiş hücreleri bulmak için tablonun satır ve sütunları arasında gezin.  
4. Birleştirilmiş hücreler bulunduğunda mesaj yazdır.

Bu C++ kodu, bir sunumda birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Tablo Hücre Kenarlıklarını Kaldırma**
1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. İndeks üzerinden bir slayt referansı alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. `AddTable` yöntemiyle slayta bir tablo ekleyin.  
6. Her hücreyi dolaşarak üst, alt, sağ ve sol kenarlıkları temizleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C++ kodu, tablo hücrelerinden kenarlıkları nasıl kaldıracağınızı gösterir:

``` cpp
// PPTX dosyasını temsil eden Presentation sınıfını örnek oluşturur
auto pres = MakeObject<Presentation>();
// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Slayta bir tablo şekli ekler
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Her hücre için kenarlık biçimini ayarlar
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// PPTX dosyasını diske yazar
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Birleştirilmiş Hücrelerde Numarlama**
İki hücre çifti (1,1) x (2,1) ve (1,2) x (2,2) birleştirilirse, ortaya çıkan tablo numaralandırılır. Bu C# kodu süreci gösterir:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Slayta bir tablo şekli ekler
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Her hücre için kenarlık biçimini ayarlar
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
// Hücreleri (1, 1) x (2, 1) birleştirir
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hücreleri (1, 2) x (2, 2) birleştirir
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTX dosyasını diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Daha sonra (1,1) ve (1,2) hücrelerini birleştirerek hücreleri daha da birleştiririz. Sonuç, ortasında büyük bir birleştirilmiş hücre bulunan bir tablo olur:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/MergeCells_out.pptx";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Slayta bir tablo şekli ekler
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Her hücre için kenarlık biçimini ayarlar
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

// Hücreleri (1, 1) x (2, 1) birleştirir
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hücreleri (1, 2) x (2, 2) birleştirir
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTX dosyasını diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bölünmüş Bir Hücrede Numarlama**
Önceki örneklerde, tablo hücreleri birleştirildiğinde, diğer hücrelerdeki numaralandırma değişmedi.  

Bu sefer birleştirilmiş hücreleri olmayan normal bir tablo alıyoruz ve ardından (1,1) hücresini bölerek özel bir tablo elde ediyoruz. Bu tablonun numaralandırmasına dikkat etmeniz gerekebilir; bu, Microsoft PowerPoint'in tablo hücrelerini numaralandırma şekli ve Aspose.Slides aynı şeyi yapar.  

Bu C++ kodu açıklanan süreci gösterir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/CellSplit_out.pptx";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Slayta bir tablo şekli ekler
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Her hücre için kenarlık biçimini ayarlar
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

// Hücreleri (1, 1) x (2, 1) birleştirir
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hücreleri (1, 2) x (2, 2) birleştirir
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// Hücreyi (1, 1) bölüyor. 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// PPTX dosyasını diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu C++ kodu, bir tablo hücresinin arka plan rengini nasıl değiştireceğinizi gösterir:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// yeni bir tablo oluştur
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// bir hücrenin arka plan rengini ayarla
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Bir Tablo Hücresinin İçine Görüntü Ekleme**
1. Bir `Presentation` sınıfının bir örneğini oluşturun.  
2. İndeks üzerinden bir slayt referansı alın.  
3. Genişliği olan bir sütun dizisi tanımlayın.  
4. Yüksekliği olan bir satır dizisi tanımlayın.  
5. `AddTable` yöntemiyle slayta bir tablo ekleyin.  
6. Görüntü dosyasını tutmak için bir `Bitmap` nesnesi oluşturun.  
7. Bitmap görüntüyü `IPPImage` nesnesine ekleyin.  
8. Tablo hücresi için `FillFormat` değerini `Picture` olarak ayarlayın.  
9. Görüntüyü tablonun ilk hücresine ekleyin.  
10. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin

Bu C# kodu, bir tablo oluştururken bir tablo hücresinin içine nasıl resim yerleştirileceğini gösterir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Slayta bir tablo şekli ekler
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Resmi alır
auto img = Images::FromFile(ImagePath);

// Resmi sunumun görüntü koleksiyonuna ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Resmi ilk tablo hücresine ekler
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// PPTX dosyasını diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/tr/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/tr/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/tr/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/tr/cpp/aspose.slides/cellformat/get_borderright/) kenarlarının ayrı özellikleri vardır, bu yüzden her bir kenarın kalınlığı ve stili farklı olabilir. Bu, makalede gösterilen bir hücre için kenar kontrolünün kenar bazında uygulanmasından mantıksal olarak çıkar.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem görüntü ne olur?**

Davranış, [fillmode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretch kullanıldığında, görüntü yeni hücreye göre ayarlanır; tile kullanıldığında, döşemeler yeniden hesaplanır. Makale, bir hücredeki görüntü gösterim modlarından bahsediyor.

**Bir hücrenin tüm içeriğine bir köprü (hyperlink) atayabilir miyim?**

[Hyperlinks](/slides/tr/cpp/manage-hyperlinks/) hücrenin metin çerçevesindeki metin (parça) seviyesinde ya da tüm tablo/şekil seviyesinde ayarlanır. Uygulamada, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Bir hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portion/) (run'lar) — yazı tipi ailesi, stil, boyut ve renk — destekler.