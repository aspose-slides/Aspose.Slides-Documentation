---
title: Správa VBA projektů v prezentacích pomocí Javy
linktitle: Prezentace pomocí VBA
type: docs
weight: 250
url: /cs/java/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- přidat makro
- odstranit makro
- extrahovat makro
- přidat VBA
- odstranit VBA
- extrahovat VBA
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak pomocí VBA a Aspose.Slides pro Javu generovat a upravovat prezentace PowerPoint a OpenDocument a zefektivnit tak svůj pracovní postup."
---
## **Úvod**

Aspose.Slides poskytuje třídy a rozhraní pro práci s makry a kódem VBA.

{{% alert title="Note" color="warning" %}} 

Když převedete prezentaci obsahující makra do jiného formátu souboru (PDF, HTML atd.), Aspose.Slides ignoruje všechna makra (makra nejsou přenesena do výsledného souboru).

Když přidáte makra do prezentace nebo znovu uložíte prezentaci obsahující makra, Aspose.Slides jednoduše zapíše bajty makr.

Aspose.Slides **nikdy** nespouští makra v prezentaci.

{{% /alert %}}

## **Přidání VBA makra**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/vbaproject/), která vám umožní vytvářet VBA projekty (a projektové reference) a upravovat existující moduly. Můžete použít rozhraní [IVbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivbaproject/) pro správu VBA vloženého do prezentace.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/vbaproject/#VbaProject--) k přidání nového VBA projektu.
1. Přidejte modul do VbaProject.
1. Nastavte zdrojový kód modulu.
1. Přidejte reference na <stdole>.
1. Přidejte reference na **Microsoft Office**.
1. Propojte reference s projektem VBA.
1. Uložte prezentaci.

Tento Java kód vám ukazuje, jak přidat VBA makro od nuly do prezentace:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace
Presentation pres = new Presentation();
try {
    // Vytvoří nový VBA projekt
    pres.setVbaProject(new VbaProject());
    
    // Přidá prázdný modul do VBA projektu
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Nastaví zdrojový kód modulu
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Vytvoří referenci na <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Vytvoří referenci na Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Přidá reference do VBA projektu
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Uloží prezentaci
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

Možná budete chtít vyzkoušet **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), což je bezplatná webová aplikace sloužící k odebrání maker z dokumentů PowerPoint, Excel a Word. 

{{% /alert %}} 

## **Odstranění VBA maker**

Pomocí vlastnosti [VbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getVbaProject--) ve třídě [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) můžete odstranit VBA makro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci obsahující makro.
1. Přistupte k modulu Macro a odstraňte jej.
1. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak odstranit VBA makro:

```java
import com.aspose.slides.*;

// Načte prezentaci obsahující makro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Přistupuje k Vba modulu a odstraňuje jej 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Uloží prezentaci
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahování VBA maker**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje VBA projekt.
3. Procházejte všechny moduly obsažené v VBA projektu a zobrazte makra.

Tento Java kód vám ukazuje, jak extrahovat VBA makra z prezentace obsahující makra:

```java
import com.aspose.slides.*;

// Načte prezentaci obsahující makro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Kontroluje, zda prezentace obsahuje VBA projekt
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kontrola, zda je VBA projekt chráněn heslem**

Pomocí metody [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA projekt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/vbaproject/).
3. Zkontrolujte, zda je VBA projekt chráněn heslem, aby bylo možné zobrazit jeho vlastnosti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Zkontrolujte, zda prezentace obsahuje VBA projekt.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

### Co se stane s makry, pokud uložím prezentaci jako PPTX?

Makra budou odstraněna, protože formát PPTX nepodporuje VBA. Chcete‑li zachovat makra, vyberte PPTM, PPSM nebo POTM.

### Může Aspose.Slides spouštět makra v prezentaci, například pro obnovení dat?

Ne. Knihovna nikdy nespouští kód VBA; provádění je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

### Je podporována práce s ActiveX ovládacími prvky propojenými s kódem VBA?

Ano, můžete přistupovat k existujícím [ActiveX ovládacím prvkům](/slides/cs/java/activex/), měnit jejich vlastnosti a odstraňovat je. To je užitečné, když makra komunikují s ActiveX.