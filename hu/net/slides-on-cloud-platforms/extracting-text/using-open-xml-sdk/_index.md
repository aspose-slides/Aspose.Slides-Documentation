---
title: "Hogyan nyerjünk ki szöveget PPT, PPTX és ODP fájlokból az Open XML SDK segítségével .NET környezetben"
linktitle: Open XML SDK
type: docs
weight: 20
url: /hu/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- felhő platformok
- felhő integráció
- Open XML SDK
- PPTX szövegkinyerés
- .NET diakezelés
- prezentáció szövegkinyerés
- mesterdia
- előadói megjegyzések
- szöveg kinyerése diákból
- C#
description: "Ismerje meg, hogyan nyerhet ki szöveget PPT, PPTX és ODP fájlokból .NET környezetben az Open XML SDK használatával, XML-alapú hozzáféréssel, teljesítmény tippekkel és konverziós megoldásokkal felhőalkalmazásokhoz."
---
## **Áttekintés**

Ez a cikk azt mutatja be, hogyan lehet szöveget kinyerni prezentációs fájlokból az Open XML SDK .NET‑ben történő használatával. Középpontjában a PPTX fájlok közvetlen XML‑hozzáférése áll, ahol a szöveg strukturált diák elemeiből nyerhető ki anélkül, hogy a diákat renderelni vagy a Microsoft PowerPointet igénybe venni kellene. A cikk emellett a teljesítményelőnyöket – gyorsabb feldolgozást és alacsonyabb memóriahasználatot – is tárgyalja.

PPT és ODP fájlok esetén a cikk megmagyarázza, hogy a szöveget nem lehet közvetlenül az Open XML SDK‑val kinyerni. Ezeket a formátumokat előbb PPTX‑re kell konvertálni, majd a kapott fájlból lehet a szöveget kinyerni.

## **Open XML SDK**

Az **Open XML SDK** egy nagyon strukturált és hatékony módszert biztosít a prezentációs fájlok szövegének kinyerésére – különösen az **PPTX** esetén, amely az Open XML szabványt követi. A mögöttes XML‑hez való közvetlen hozzáférés révén ez az SDK gyorsabb és rugalmasabb diatartalom-kezelést tesz lehetővé a hagyományos módszerekhez képest.

## **Közvetlen XML‑hozzáférés**

- **Szöveg közvetlen elemzése**: Az Open XML SDK lehetővé teszi a szöveg kinyerését az XML‑részekből anélkül, hogy a diákat renderelni kellene.
- **Strukturált elemek**: Mivel a szöveg jól definiált XML‑címkékben van tárolva, egyszerűbb a lekérdezés és a feldolgozás.

### **Példa: Szöveg kinyerése közvetlenül a dia XML‑tartalmából**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **Teljesítményelőnyök**

- **Gyorsabb kinyerés**: Megkerüli a PowerPoint vagy más magas szintű API‑k megnyitásának terheit.
- **Alacsonyabb memóriahasználat**: Csak a releváns XML‑részeket érinti, csökkentve az erőforrás‑fogyasztást.
- **Microsoft PowerPoint nélkül**: Nem igényel extra telepítést.

### **Példa: Hatékony szövegkinyerés a teljes prezentáció betöltése nélkül**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **Szövegelemek azonosítása**

### **A prezentációkból történő szövegkinyerés részletei**

A szöveg kinyerésekor vegye figyelembe a következő tényezőket:

- **A szöveg különböző szakaszokban helyezkedhet el**: Rendszeres diák, mesterdiák, elrendezések vagy jegyzetek.
- **Alapértelmezett helyőrzők**: A mesterdiák és elrendezések tartalmazhatnak helyőrzőket (például „Kattintson a mestercím stílus szerkesztéséhez”), amelyek nem a tényleges prezentációs tartalom.
- **Üres vagy rejtett szöveg szűrése**: Egyes elemek lehetnek üresek vagy nem szándékoznak megjelenni.

### **Szöveget tartalmazó címkék**

Egy **PPTX** fájlban a szöveg általában a következőkben tárolódik:
- `<a:t>` elemek `<a:p>` (bekezdések) belsejében
- `<a:r>` elemek (bekezdésen belüli szövegszegmensek)

### **Példa: Minden szövegelem kinyerése egy diáról**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP és PPT**

### **Közvetlen szövegkinyerés hiánya**

- A **PPTX**‑től eltérően a **PPT** (bináris formátum) és az **ODP** (OpenDocument Presentation) **nem támogatott** az Open XML SDK által.
- A **PPT** tartalmat zárt bináris formátumban tárolja, ami nehezíti a szövegkinyerést.
- Az **ODP** az **OpenDocument XML**‑t használja, amely szerkezetileg eltér a PPTX‑től.

### **Megoldás: Konvertálás PPTX‑re**

A **PPT** vagy **ODP** szövegkinyeréséhez a javasolt lépések:

1. **PPT → PPTX** konvertálása PowerPointtal vagy egy harmadik féltől származó eszközzel.  
2. **ODP → PPTX** konvertálása LibreOffice‑val vagy PowerPointtal.  
3. **Szöveg kinyerése** az új PPTX‑ből az Open XML SDK‑val.

### **Példa: ODP konvertálása PPTX‑re a LibreOffice parancssor segítségével**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Támogatott platformok és keretrendszerek**

- **Windows**: .NET Framework 4.6.1 és újabb, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Felhői környezetek**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker‑konténerek.
- **Kompatibilitás Office‑alkalmazásokkal**: Microsoft Office telepítése nem szükséges.
- **Támogatott programnyelvek**: Az Open XML SDK használható **C#**, **VB.NET**, **F#** és más, .NET‑t támogató nyelvekkel.

## **Összegzés**

Az **Open XML SDK** **PPTX** szövegkinyerésre való használata hatékonyságot és átláthatóságot biztosít, míg a **PPT** és **ODP** esetén egy kezdeti konverziós lépés szükséges a zökkenőmentes feldolgozáshoz. Ennek az eljárásnak az alkalmazásával **magas teljesítmény**, **rugalmasság** és **széleskörű kompatibilitás** érhető el a modern .NET‑alkalmazásokban.