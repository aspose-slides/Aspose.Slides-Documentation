---
title: Správa BLOBů prezentace v C++ pro efektivní využití paměti
linktitle: Spravovat BLOB
type: docs
weight: 10
url: /cs/cpp/manage-blob/
keywords:
- velký objekt
- velká položka
- velký soubor
- přidat BLOB
- exportovat BLOB
- přidat obrázek jako BLOB
- snížit paměť
- spotřeba paměti
- velká prezentace
- dočasný soubor
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravujte data BLOB v Aspose.Slides pro C++, aby se zjednodušily operace se soubory PowerPoint a OpenDocument pro efektivní zpracování prezentací."
---
## **Přehled**

Aspose.Slides poskytuje zpracování založené na BLOB pro velká binární data v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrázky, zvukem, videem a soubory prezentací.

Tento článek ukazuje, jak použít zpracování založené na BLOB k přidání velkých médií do prezentace, exportu velkých médií z prezentace a efektivnějšímu načítání velkých prezentací. Také vysvětluje, jak lze během zpracování používat dočasné soubory a jak změnit složku, ve které jsou uloženy.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velký prvek (foto, prezentace, dokument nebo média) uložený v binárním formátu.

Aspose.Slides for C++ vám umožňuje používat BLOBy pro objekty způsobem, který snižuje spotřebu paměti, když jsou zapojeny velké soubory.

## **Použijte BLOB ke snížení spotřeby paměti**

### **Přidání velkého souboru pomocí BLOB do prezentace**

[Aspose.Slides](/slides/cs/cpp/) for C++ vám umožňuje přidávat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOB, aby se snížila spotřeba paměti.

Tento C++ kód vám ukazuje, jak přidat velký video soubor pomocí procesu BLOB do prezentace:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Vytvoří novou prezentaci, do které bude video přidáno
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Přidáme video do prezentace - zvolili jsme chování KeepLocked, protože
// neplánujeme přistupovat k souboru "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Uloží prezentaci. Během vytváření velké prezentace zůstává spotřeba paměti
// nízká během životního cyklu objektu pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Export velkého souboru pomocí BLOB z prezentace**

Aspose.Slides for C++ umožňuje exportovat velké soubory (například audio nebo video soubor) pomocí procesu zahrnujícího BLOB z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl načten do paměti počítače. Exportem souboru pomocí procesu BLOB udržíte spotřebu paměti nízkou.

Tento kód v C++ demonstruje popsanou operaci:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Vytvoří instanci Presentation a uzamkne soubor "hugePresentationWithAudiosAndVideos.pptx" file.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Uložíme každé video do souboru. Abychom zabránili vysoké spotřebě paměti, potřebujeme buffer, který bude použit
// k přenosu dat z video streamu prezentace do streamu nově vytvořeného video souboru.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Prochází videa
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Otevírá video stream prezentace. Všimněte si, že jsme úmyslně vyhnuli přístupu k metodám
	// jako video->get_BinaryData - protože tato metoda vrací pole bajtů obsahující celé video, což pak
	// způsobí načtení bajtů do paměti. Používáme video->GetStream, který vrátí Stream - a NE
	// vyžaduje načtení celého videa do paměti.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Spotřeba paměti zůstane nízká bez ohledu na velikost videa nebo prezentace,
}

// V případě potřeby můžete použít stejné kroky pro audio soubory.
```

### **Přidání obrázku jako BLOB do prezentace**

Pomocí metod rozhraní [**IImageCollection**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_image_collection) a třídy [**ImageCollection**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.image_collection) můžete přidat velký obrázek jako stream, aby byl považován za BLOB.

Tento C++ kód vám ukazuje, jak přidat velký obrázek pomocí procesu BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// vytvoří novou prezentaci, do které bude obrázek přidán.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Přidáme obrázek do prezentace - zvolíme chování KeepLocked, protože
// NECHCEME přistupovat k souboru "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Uloží prezentaci. Zatímco se vytváří velká prezentace, spotřeba paměti 
// zůstává nízká během životního cyklu objektu pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Paměť a velké prezentace**

Typicky, pro načtení velké prezentace, počítače vyžadují hodně dočasné paměti. Veškerý obsah prezentace je načten do paměti a soubor (ze kterého byla prezentace načtena) přestává být používán.

Uvažujme velkou PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda načtení prezentace je popsána v tomto C++ kódu:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Tato metoda však spotřebuje přibližně 1,6 GB dočasné paměti.

### **Načtení velké prezentace jako BLOB**

Pomocí procesu zahrnujícího BLOB můžete načíst velkou prezentaci při použití malého množství paměti. Tento C++ kód popisuje implementaci, kde je proces BLOB použit k načtení velkého souboru prezentace (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Změna složky pro dočasné soubory**

Když je použit proces BLOB, váš počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uloženy v jiné složce, můžete změnit nastavení úložiště pomocí `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Když použijete `TempFilesRootPath`, Aspose.Slides automaticky nevytvoří složku pro uložení dočasných souborů. Musíte složku vytvořit ručně.
{{% /alert %}}

### **Uvolnění objektů prezentace pro uvolnění paměti**

Při zpracování velkých prezentací zajistěte, aby instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) byla řádně uvolněna, aby byla uvolněna paměť, kterou zabírala. Po dokončení práce s prezentací zavolejte `Dispose()`, abyste uvolnili neřízené prostředky.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...zpracujte prezentaci...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitně uvolněte prostředky.
presentation->Dispose();
```

## **Často kladené otázky**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena možnostmi BLOB?**

Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také zahrnuje zpracování BLOB při načítání nebo ukládání. Tyto objekty jsou řízeny politikami BLOB, které umožňují spravovat využití paměti a přenášet data do dočasných souborů podle potřeby.

**Kde mohu nakonfigurovat pravidla zpracování BLOB během načítání prezentace?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/) s [BlobManagementOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOB, povolíte nebo zakážete dočasné soubory, vyberete kořenovou cestu pro dočasné soubory a určíte chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak najít rovnováhu mezi rychlostí a pamětí?**

Ano. Udržení BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížení limitu paměti přesune více práce do dočasných souborů, čímž snižuje RAM za cenu dalšího I/O. Použijte metodu [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/), abyste dosáhli správné rovnováhy pro vaše zatížení a prostředí.

**Pomáhají možnosti BLOB při otevírání extrémně velkých prezentací (např. v gigabytech)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může značně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých prezentací.

**Mohu použít politiky BLOB při načítání ze streamů místo souborů na disku?**

Ano. Stejná pravidla se vztahují na streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou používány, pokud jsou povoleny, čímž je používání paměti během zpracování předvídatelné.