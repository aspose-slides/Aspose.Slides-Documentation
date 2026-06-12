---
title: Automatická aktualizace OLE objektů pomocí doplňku PowerPoint
type: docs
weight: 10
url: /cs/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE objekt
- aktualizovat OLE
- automaticky
- doplňek
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak automaticky aktualizovat OLE grafy a objekty v PowerPointu pomocí doplňku a Aspose.Slides pro Java, včetně praktického kódu a tipů na optimalizaci."
---
## **Úvod**

Jednou z nejčastějších otázek, které kladou zákazníci Aspose.Slides pro Java, je, jak vytvořit nebo upravit editovatelné grafy (nebo jiné OLE objekty), aby se automaticky aktualizovaly při otevření prezentace. Bohužel PowerPoint nepodporuje automatické makra stejným způsobem jako Excel a Word. Jediná dostupná makra jsou `Auto_Open` a `Auto_Close` a tato se spouštějí automaticky pouze z doplňku. Tento stručný technický tip ukazuje, jak toho dosáhnout.

## **Automaticky aktualizovat OLE objekty**

Nejprve jsou k dispozici několikanásobné bezplatné doplňky, které do PowerPointu přidávají funkci makra Auto_Open, například [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) a [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Po instalaci jednoho z těchto doplňků stačí přidat makro `Auto_Open()` (nebo `OnPresentationOpen()`, pokud používáte Event Generator) do šablony prezentace, jak je uvedeno níže:

```java
// Procházet každý snímek v prezentaci.
for (var oSlide : ActivePresentation.Slides) {
    // Procházet všechny tvary na aktuálním snímku.
    for (var oShape : oSlide.Shapes) {
        // Zkontrolovat, zda je tvar OLE objektem.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Nalezen OLE objekt. Získat jeho referenci a poté jej aktualizovat.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Nyní ukončit program OLE serveru.
            // Tím se uvolní paměť a zabrání se problémům.
            // Také nastavit oObject na Nothing pro uvolnění objektu.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Jakékoli změny provedené na OLE objektech pomocí Aspose.Slides pro Java budou automaticky aktualizovány, když PowerPoint otevře prezentaci. Pokud máte mnoho OLE objektů a nechcete je všechny aktualizovat, stačí přidat vlastní značku k tvarům, které je třeba zpracovat, a v makru tuto značku zkontrolovat.