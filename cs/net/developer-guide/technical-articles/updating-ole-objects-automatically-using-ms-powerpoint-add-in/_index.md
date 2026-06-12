---
title: Automatická aktualizace OLE objektů pomocí doplňku PowerPoint
type: docs
weight: 10
url: /cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE objekt
- aktualizovat OLE
- automaticky
- doplněk
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak automaticky aktualizovat OLE grafy a objekty v PowerPointu pomocí doplňku a Aspose.Slides pro .NET, včetně praktického kódu a tipů na optimalizaci."
---
## **Úvod**

Jedna z nejčastěji kladených otázek zákazníků Aspose.Slides for .NET je, jak vytvořit nebo upravit editovatelné grafy (nebo jiné OLE objekty), aby se automaticky aktualizovaly při otevření prezentace. Bohužel PowerPoint nepodporuje automatické makra stejným způsobem jako Excel a Word. Jediná dostupná makra jsou `Auto_Open` a `Auto_Close` a tato se spouštějí automaticky pouze z doplňku. Tento krátký technický tip ukazuje, jak toho dosáhnout.

## **Automatická aktualizace OLE objektů**

Nejprve je k dispozici několik bezplatných doplňků, které přidávají funkci makra Auto_Open do PowerPointu, například [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) a [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Po instalaci jednoho z těchto doplňků stačí do šablony prezentace přidat makro `Auto_Open()` (nebo `OnPresentationOpen()`, pokud používáte Event Generator), jak je uvedeno níže:

```cs
public void Auto_Open()
{
    // Procházet každým snímkem v prezentaci.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Procházet všechny tvary na aktuálním snímku.
        foreach (var oShape in oSlide.Shapes)
        {
            // Zkontrolovat, zda je tvar OLE objektem.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Nalezen OLE objekt. Získat jeho referenci a poté jej aktualizovat.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Nyní ukončit program OLE serveru.
                // Uvolní paměť a zabrání problémům.
                // Také nastavit oObject na Nothing pro uvolnění objektu.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Jakékoli změny provedené na OLE objektech pomocí Aspose.Slides for .NET budou při otevření prezentace v PowerPointu automaticky aktualizovány. Pokud máte mnoho OLE objektů a nechcete je všechny aktualizovat, jednoduše přidejte vlastní značku k tvarům, které je potřeba zpracovat, a v makru ji zkontrolujte.