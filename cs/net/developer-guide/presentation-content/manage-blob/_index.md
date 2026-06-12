---
title: Správa BLOB v prezentacích v .NET pro efektivní využití paměti
linktitle: Správa BLOB
type: docs
weight: 10
url: /cs/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Spravujte BLOB data v Aspose.Slides pro .NET, aby bylo zjednodušeno zpracování souborů PowerPoint a OpenDocument pro efektivní manipulaci s prezentacemi."
---
## **Přehled**

Aspose.Slides poskytuje zpracování založené na BLOB pro velká binární data v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrázky, zvuky, videi a soubory prezentací.

Tento článek ukazuje, jak použít zpracování založené na BLOB k přidání velkých médií do prezentace, exportu velkých médií z prezentace a efektivnějšímu načítání velkých prezentací. Také vysvětluje, jak mohou být během zpracování použity dočasné soubory a jak změnit složku, kde jsou uloženy.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (fotografie, prezentace, dokument nebo médium) uložená v binárních formátech. 

Aspose.Slides pro .NET vám umožňuje používat BLOBy pro objekty tak, že snižuje spotřebu paměti při práci s velkými soubory. 

## **Použít BLOB ke snížení spotřeby paměti**

### **Přidat velký soubor pomocí BLOB do prezentace**

[Aspose.Slides](/slides/cs/net/) pro .NET vám umožňuje přidat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOBy, aby se snížila spotřeba paměti.

Tento C# kód vám ukazuje, jak přidat velký video soubor pomocí procesu BLOB do prezentace:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Vytvoří novou prezentaci, do které bude video přidáno
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Přidáme video do prezentace – zvolili jsme chování KeepLocked, protože
        // neplánujeme přistupovat k souboru "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Uloží prezentaci. I když je vytvořena velká prezentace,
        // zůstává spotřeba paměti nízká během životního cyklu objektu pres.
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Exportovat velký soubor pomocí BLOB z prezentace**

Aspose.Slides pro .NET vám umožňuje exportovat velké soubory (v tomto případě audio nebo video soubor) pomocí procesu zahrnujícího BLOBy z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl soubor načten do paměti vašeho počítače. Exportováním souboru pomocí procesu BLOB udržíte spotřebu paměti nízkou. 

Tento kód v C# demonstruje popsanou operaci:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Zamkne zdrojový soubor a NENÁHRÁ jej do paměti
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Vytvoří instanci Presentation a zamkne soubor "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Uložíme každé video do souboru. Pro zamezení vysoké spotřeby paměti potřebujeme buffer, který bude použit
	// k přenosu dat ze streamu videa v prezentaci do streamu nově vytvořeného video souboru.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Otevírá stream videa v prezentaci. Všimněte si, že jsme úmyslně vyhnuli přístupu k vlastnostem
		// jako video.BinaryData – protože tato vlastnost vrací pole bytů obsahující celé video, což pak
		// způsobí načtení bytů do paměti. Používáme video.GetStream, který vrátí Stream – a NENÍ
		//  potřeba načítat celé video do paměti.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// Spotřeba paměti zůstane nízká bez ohledu na velikost videa nebo prezentace,
	}

	// V případě potřeby můžete použít stejný postup i pro audio soubory. 
}
```

### **Přidat obrázek jako BLOB do prezentace**

Pomocí metod rozhraní [**IImageCollection**](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection) a třídy [**ImageCollection**](https://reference.aspose.com/slides/cs/net/aspose.slides/imagecollection) můžete přidat velký obrázek jako proud, aby byl zpracován jako BLOB. 

Tento C# kód vám ukazuje, jak přidat velký obrázek pomocí procesu BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// vytvoří novou prezentaci, do které bude obrázek přidán.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Přidáme obrázek do prezentace – zvolíme chování KeepLocked, protože
		// NEPLÁNUJEME přistupovat k souboru "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Uloží prezentaci. I když je vytvořena velká prezentace, spotřeba paměti 
		// zůstává nízká během životního cyklu objektu pres.
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Paměť a velké prezentace**

Obvykle k načtení velké prezentace počítače vyžadují hodně dočasné paměti. Veškerý obsah prezentace je načten do paměti a soubor (ze kterého byla prezentace načtena) již není používán. 

Uvažujme velkou PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda načtení prezentace je popsaná v tomto C# kódu:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Tato metoda však spotřebuje přibližně 1,6 GB dočasné paměti. 

### **Načíst velkou prezentaci jako BLOB**

Pomocí procesu zahrnujícího BLOB můžete načíst velkou prezentaci s malou spotřebou paměti. Tento C# kód popisuje implementaci, kde je proces BLOB použit k načtení velkého souboru prezentace (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Změna složky pro dočasné soubory**

Když je použit proces BLOB, váš počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uloženy v jiné složce, můžete změnit nastavení úložiště pomocí `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
Když použijete `TempFilesRootPath`, Aspose.Slides automaticky nevytváří složku pro ukládání dočasných souborů. Musíte složku vytvořit ručně. 
{{% /alert %}}

### **Uvolnit objekty prezentace pro uvolnění paměti**

Při zpracování velkých prezentací zajistěte, aby instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) byla řádně uvolněna, aby byla uvolněna paměť, kterou zabírala. Doporučený způsob je použít příkaz `using` nebo deklaraci, jak je ukázáno v příkladech výše; automaticky uvolní prezentaci a uvolní neřízené prostředky po opuštění bloku.

Pokud vytvoříte prezentaci bez bloku `using`, výslovně zavolejte `Dispose()` poté, co jste s ní dokončili.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...zpracovat prezentaci...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Explicitně uvolněte prostředky.
presentation.Dispose();
```

## **Často kladené otázky**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena nastavením BLOB?**

Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také zahrnuje zpracování BLOB při načítání nebo ukládání. Tyto objekty jsou řízeny politikami BLOB, které vám umožňují spravovat využití paměti a přelít data do dočasných souborů podle potřeby.

**Kde mohu nakonfigurovat pravidla zpracování BLOB během načítání prezentace?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/) s [BlobManagementOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOB, povolíte nebo zakážete dočasné soubory, vyberete kořenovou cestu pro dočasné soubory a zvolíte chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak najít rovnováhu mezi rychlostí a pamětí?**

Ano. Udržování BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížením limitu paměti se více práce přesune na dočasné soubory, což snižuje RAM za cenu dalšího vstupně‑výstupního zatížení. Nastavte práh [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/), aby byl dosažen správný poměr pro vaše pracovní zatížení a prostředí.

**Pomáhají nastavení BLOB při otevírání extrémně velkých prezentací (např. gigabajty)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může výrazně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých prezentací.

**Mohu použít politiky BLOB při načítání ze streamů místo souborů na disku?**

Ano. Stejná pravidla platí pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou používány, pokud jsou povoleny, což udržuje předvídatelnou spotřebu paměti během zpracování.