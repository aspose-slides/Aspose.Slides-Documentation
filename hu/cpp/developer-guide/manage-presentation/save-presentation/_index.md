---
title: Bemutatók mentése C++-ban
linktitle: Bemutató mentése
type: docs
weight: 80
url: /hu/cpp/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- bemutató mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- bemutató fájlba
- bemutató folyamba
- előre definiált nézettípus
- Szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentés előrehaladása
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan menthet bemutatókat C++-ban az Aspose.Slides használatával—exportálás PowerPoint vagy OpenDocument formátumba, miközben megőrzi a elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Open Presentations in C++](/slides/hu/cpp/open-presentation/) bemutatta, hogyan használható a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály egy bemutató megnyitásához. Ez a cikk megmagyarázza, hogyan hozhatunk létre és menthetünk bemutatókat. A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály tartalmazza egy bemutató tartalmát. Legyen szó egy új bemutató létrehozásáról vagy egy meglévő módosításáról, a munka befejezése után menteni kell. Az Aspose.Slides for C++-bal **fájlba** vagy **folyamba** menthetünk. Ez a cikk ismerteti a bemutató mentésének különböző módjait.

## **Bemutatók mentése fájlokba**

A bemutatót fájlba menthetjük a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály `Save` metódusának meghívásával. A metódusnak át kell adni a fájl nevét és a mentési formátumot. Az alábbi példa azt mutatja, hogyan menthetünk egy bemutatót az Aspose.Slides segítségével.

```cpp
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Végezzen itt némi munkát...

// Mentse a prezentációt egy fájlba.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Bemutatók mentése folyamatokra**

A bemutatót egy kimeneti folyam átadásával menthetjük a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály `Save` metódusának. A bemutató számos folyam típusba írható. Az alábbi példában egy új bemutatót hozunk létre, és fájlfolyamba mentjük.

```cpp
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Mentse a prezentációt a folyamra.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Bemutatók mentése előre definiált nézettípussal**

Az Aspose.Slides lehetővé teszi a PowerPoint által a generált bemutató megnyitásakor használt kezdeti nézet beállítását a [ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) osztályon keresztül. A [set_LastView](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/set_lastview/) metódust a [ViewType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewtype/) felsorolás egy értékével kell meghívni.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bemutatók mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi a bemutató mentését a szigorú Office Open XML formátumban. A mentéskor használja a [PptxOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/) osztályt, és állítsa be a `Conformance` tulajdonságát. Ha a `Conformance.Iso29500_2008_Strict` értéket adja meg, a kimeneti fájl a szigorú Office Open XML formátumban kerül mentésre.

Az alábbi példa egy bemutatót hoz létre, és a szigorú Office Open XML formátumban menti.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>();

// Mentse a prezentációt a szigorú Office Open XML formátumban.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a kicsomagolt és a tömörített méretre, valamint a teljes archívum méretére, és legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátum kiterjesztések ezeket a korlátokat 2^64‑re emelik.

A [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) metódus lehetővé teszi a ZIP64 kiterjesztések használatának megválasztását Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- `IfNecessary` csak akkor alkalmazza a ZIP64 kiterjesztéseket, ha a bemutató meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- `Never` soha nem használja a ZIP64 kiterjesztéseket.
- `Always` mindig használja a ZIP64 kiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthetünk egy bemutatót PPTX‑ként ZIP64 kiterjesztésekkel engedélyezve:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}
Amikor a `Zip64Mode.Never` beállítással ment, egy [PptxException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxexception/) keletkezik, ha a bemutató nem menthető ZIP32 formátumban.
{{% /alert %}}

## **Bemutatók mentése a bélyegkép frissítése nélkül**

A [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) metódus szabályozza a bélyegkép generálását PPTX mentésekor:

- Ha `true`, a bélyegkép mentés közben frissül. Ez az alapértelmezett.
- Ha `false`, a jelenlegi bélyegkép megmarad. Ha a bemutatónak nincs bélyegképe, nem kerül generálásra.

Az alábbi kódban a bemutató PPTX‑ként mentésre kerül a bélyegkép frissítése nélkül.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Ez a beállítás segít csökkenteni a PPTX formátumba történő mentéshez szükséges időt.
{{% /alert %}}

## **Mentés előrehaladásának százalékos megjelenítése**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isaveoptions/) interfész `set_ProgressCallback` metódusán és az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/) osztályon keresztül használják. Egy [IProgressCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprogresscallback/) implementációt adjon meg a `set_ProgressCallback` segítségével, hogy a mentés előrehaladását százalékban kapja meg.

Az alábbi kódrészletek bemutatják, hogyan használja az `IProgressCallback`-et.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Használja itt a folyamat százalékos értékét.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Az Aspose kifejlesztett egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) saját API-jával. Az alkalmazás lehetővé teszi a bemutató több fájlra bontását a kiválasztott diák új PPTX vagy PPT fájlként való mentésével.
{{% /alert %}}

## **GYIK**

**Támogatja a „gyors mentést” (inkrementális mentés) úgy, hogy csak a változások íródnak?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Biztonságos-e ugyanazt a Presentation példányt több szálról menteni?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példány **nem szálbiztos** (/slides/hu/cpp/multithreading/); csak egy szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal mentéskor?**

A [hiperhivatkozások](/slides/hu/cpp/manage-hyperlinks/) megmaradnak. A külsőleg linkelt fájlok (például relatív útvonalakon hivatkozott videók) nem kerülnek automatikusan másolásra – biztosítsa, hogy a hivatkozott útvonalak elérhetők maradjanak.

**Beállítható/fájlba menthető-e a dokumentum metaadata (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [dokumentumtulajdonságok](/slides/hu/cpp/presentation-properties/) támogatottak, és a mentéskor a fájlba kerülnek.