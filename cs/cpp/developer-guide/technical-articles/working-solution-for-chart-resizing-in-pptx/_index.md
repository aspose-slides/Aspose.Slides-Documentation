---
title: Řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 60
url: /cs/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excelu
- OLE objekt
- vložit graf
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excelu s Aspose.Slides pro C++. Naučte se dvě metody s kódem, jak udržet velikosti konzistentní."
---
## **Pozadí**

Bylo zaznamenáno, že grafy Excelu vložené jako OLE objekty v prezentaci PowerPoint prostřednictvím komponent Aspose jsou po svém prvním aktivování změněny na neurčitou velikost. Toto chování způsobuje výrazný vizuální rozdíl v prezentaci mezi stavem grafu před a po aktivaci. Tým Aspose problém podrobně prozkoumal a našel řešení. Tento článek popisuje příčiny problému a odpovídající opravu.

V [předchozím článku](/slides/cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excelu pomocí Aspose.Cells pro C++ a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro C++. Pro řešení [problému s náhledem objektu](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámečku grafu. V výstupní prezentaci, když dvakrát kliknete na OLE objektový rámeček zobrazující obrázek grafu, aktivuje se graf Excelu. Uživatelé mohou provést libovolné požadované změny v podkladovém sešitu Excel a poté se vrátit na příslušný snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámečku se po návratu uživatele na snímek změní a faktor změny velikosti se liší v závislosti na původních velikostech jak OLE objektového rámečku, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, snaží se při první aktivaci zachovat svou původní velikost. OLE objektový rámeček však má svou vlastní velikost. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint vyjednávají velikost a zachovávají správné proporce jako součást procesu vkládání. V závislosti na rozdílech mezi velikostí okna Excelu a velikostí nebo umístěním OLE objektového rámečku dochází k změně velikosti.

## **Fungující řešení**

Existují dva možné scénáře pro vytváření prezentací PowerPoint pomocí Aspose.Slides pro C++.

**Scénář 1:** Vytvořit prezentaci na základě existující šablony.

**Scénář 2:** Vytvořit prezentaci od nuly.

Řešení, které zde poskytujeme, platí pro oba scénáře. Základem všech přístupů k řešení je stejné: **velikost okna vloženého OLE objektu by měla odpovídat OLE objektovému rámečku na snímku PowerPointu**. Nyní probereme dva přístupy k tomuto řešení.

## **První přístup**

V tomto přístupu se naučíme, jak nastavit velikost okna vloženého sešitu Excel tak, aby odpovídala velikosti OLE objektového rámečku na snímku PowerPointu.

**Scénář 1**

Předpokládejme, že máme definovanou šablonu a chceme na její základě vytvářet prezentace. Předpokládejme, že v šabloně je tvar na indexu 2, kam chceme umístit OLE rámec obsahující vložený sešit Excel. V tomto scénáři je velikost OLE objektového rámečku předdefinována – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost okna sešitu na velikost tohoto tvaru. Následující úryvek kódu slouží tomuto účelu:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Definujte velikost grafu pomocí okna. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Nastavte šířku okna sešitu v palcích (děleno 72, protože PowerPoint používá 72 pixelů na palec).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Nastavte výšku okna sešitu v palcích.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Uložte sešit do paměťového proudu.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Vytvořte OLE objektový rámec s vloženými daty Excelu.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scénář 2**

Řekněme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím úryvku kódu vytvoříme OLE objektový rámec vysoký 4 palce a široký 9,5 palce na souřadnicích x = 0,5 palce a y = 1 palce na snímku. Poté nastavíme okno sešitu Excel na stejnou velikost – 4 palce vysoké a 9,5 palce široké.

```cpp
// Naše požadovaná výška.
int32_t desiredHeight = 288; // 4 palce (4 * 72)

// Naše požadovaná šířka.
int32_t desiredWidth = 684; // 9,5 palce (9.5 * 72)

// Definujte velikost grafu pomocí okna. 
chart->SetSizeWithWindow(true);

// Nastavte šířku okna sešitu v palcích.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Nastavte výšku okna sešitu v palcích.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Uložte sešit do paměťového proudu.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Vytvořte OLE objektový rámec s vloženými daty Excelu.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Druhý přístup**

V tomto přístupu se naučíme, jak nastavit velikost grafu ve vloženém sešitu Excel tak, aby odpovídala velikosti OLE objektového rámečku na snímku PowerPointu. Tento přístup je užitečný, když je velikost grafu známá předem a nikdy se nezmění.

**Scénář 1**

Předpokládejme, že máme definovanou šablonu a chceme na její základě vytvářet prezentace. Předpokládejme, že v šabloně je tvar na indexu 2, kam zamýšlíme umístit OLE rámec obsahující vložený sešit Excel. V tomto scénáři je velikost OLE rámce předdefinována – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost grafu v sešitu tak, aby se rovnala velikosti tvaru. Následující úryvek kódu slouží tomuto účelu:

```cpp
// Definujte velikost grafu bez okna. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Nastavte šířku grafu v pixelech (vynásobte 96, protože Excel používá 96 pixelů na palec).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Nastavte výšku grafu v pixelech.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Definujte velikost tisku grafu.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Uložte sešit do paměťového proudu.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Vytvořte OLE objektový rámec s vloženými daty Excelu.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scénář 2**

Předpokládejme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím úryvku kódu vytvoříme OLE objektový rámec výšky 4 palce a šířky 9,5 palce na snímku na souřadnicích x = 0,5 palce a y = 1 palce. Také nastavíme odpovídající velikost grafu na stejné rozměry: výška 4 palce a šířka 9,5 palce.

```cpp
// Naše požadovaná výška.
int32_t desiredHeight = 288; // 4 palce (4 * 576)

// Naše požadovaná šířka.
int32_t desiredWidth = 684; // 9,5 palce (9.5 * 576)

// Definujte velikost grafu bez okna. 
chart->SetSizeWithWindow(false);

// Nastavte šířku grafu v pixelech.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Nastavte výšku grafu v pixelech.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Uložte sešit do paměťového proudu.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Vytvořte OLE objektový rámec s vloženými daty Excelu.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Závěr**

Existují dva přístupy k řešení problému se změnou velikosti grafu. Výběr přístupu závisí na požadavcích a konkrétním použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Také neexistuje žádný limit velikosti OLE objektového rámce v tomto řešení.

## **Často kladené otázky**

**Proč se můj vložený graf Excelu po aktivaci v PowerPointu změní velikost?**

K tomu dochází, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

**Je možné tomuto problému se změnou velikosti zcela předejít?**

Ano. Pokud před vložením nastavíte velikost okna sešitu Excel nebo velikost grafu tak, aby odpovídala velikosti OLE objektového rámce, můžete udržet velikosti grafů konzistentní.

**Který přístup mám zvolit, nastavit velikost okna sešitu nebo velikost grafu?**

Použijte **přístup 1 (velikost okna)**, pokud chcete zachovat poměr stran sešitu a případně umožnit pozdější změnu velikosti. Použijte **přístup 2 (velikost grafu)**, pokud jsou rozměry grafu pevně dané a nebudou se po vložení měnit.

**Budou tyto metody fungovat jak pro prezentace založené na šabloně, tak pro nové prezentace?**

Ano. Oba přístupy fungují stejně pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE objektového rámce?**

Ne. OLE rámec můžete nastavit na libovolnou velikost, pokud se správně škáluje k velikosti sešitu nebo grafu.

**Mohu tyto metody použít s grafy vytvořenými v jiných tabulkových programech?**

Příklady jsou navrženy pro grafy Excelu vytvořené pomocí Aspose.Cells, ale principy platí i pro jiné OLE‑kompatibilní tabulkové programy, pokud podporují podobné možnosti nastavení velikosti.

## **Související sekce**

- [Vytváření grafů Excel a jejich vložení jako OLE objekty do prezentací](/slides/cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)