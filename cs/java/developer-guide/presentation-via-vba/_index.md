---
title: Správa projektů VBA v prezentacích pomocí Javy
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
description: "Objevte, jak pomocí Aspose.Slides pro Javu generovat a manipulovat s prezentacemi PowerPoint a OpenDocument prostřednictvím VBA a zefektivnit svůj pracovní postup."
---
## **Úvod**

Aspose.Slides poskytuje třídy a rozhraní pro práci s makry a kódem VBA.

{{% alert title="Note" color="warning" %}} 

Když převedete prezentaci obsahující makra do jiného formátu souboru (PDF, HTML, atd.), Aspose.Slides ignoruje všechna makra (makra nejsou přenesena do výsledného souboru).

Když přidáte makra do prezentace nebo znovu uložíte prezentaci obsahující makra, Aspose.Slides jednoduše zapíše bajty makr.

Aspose.Slides **nikdy** nespouští makra v prezentaci.

{{% /alert %}}

## **Přidání VBA makr**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/vbaproject/) , která vám umožní vytvářet projekty VBA (a odkazy na projekty) a upravovat existující moduly. Pro správu VBA vloženého v prezentaci můžete použít rozhraní [IVbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivbaproject/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) .
1. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/vbaproject/#VbaProject--) , abyste přidali nový projekt VBA.
1. Přidejte modul do VbaProject.
1. Nastavte zdrojový kód modulu.
1. Přidejte odkazy na <stdole>.
1. Přidejte odkazy na **Microsoft Office**.
1. Přiřaďte odkazy k projektu VBA.
1. Uložte prezentaci.

Tento Java kód ukazuje, jak od začátku přidat VBA makro do prezentace:

```java
// Vytvoří instanci třídy prezentace
Presentation pres = new Presentation();
try {
    // Vytvoří nový projekt VBA
    pres.setVbaProject(new VbaProject());
    
    // Přidá prázdný modul do projektu VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Nastaví zdrojový kód modulu
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Vytvoří odkaz na <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Vytvoří odkaz na Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Přidá odkazy do projektu VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Uloží prezentaci
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Možná budete chtít vyzkoušet **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), což je bezplatná webová aplikace určená k odstraňování maker z dokumentů PowerPoint, Excel a Word. 

{{% /alert %}} 

## **Odstranění VBA makr**

Pomocí vlastnosti [VbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getVbaProject--) , která je součástí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) , můžete odstranit VBA makro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) , načtěte prezentaci obsahující makro.
2. Přistupte k modulu Macro a odstraňte jej.
3. Uložte upravenou prezentaci.

Tento Java kód ukazuje, jak odstranit VBA makro:

```java
// Načte prezentaci obsahující makro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Přistoupí k modulu Vba a odstraní jej 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Uloží prezentaci
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahování VBA makr**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) , načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje projekt VBA.
3. Projděte všechny moduly obsažené v projektu VBA a zobrazte makra.

Tento Java kód ukazuje, jak extrahovat VBA makra z prezentace obsahující makra:

```java
// Načte prezentaci obsahující makro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Kontroluje, zda prezentace obsahuje projekt VBA
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

## **Kontrola, zda je projekt VBA chráněn heslem**

Pomocí metody [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) , načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA projekt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/vbaproject/).
3. Zkontrolujte, zda je projekt VBA chráněn heslem, a prohlédněte si jeho vlastnosti.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Zkontrolujte, zda prezentace obsahuje projekt VBA.
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

**Co se stane s makry, pokud uložíme prezentaci jako PPTX?**

Makra budou odstraněna, protože formát PPTX nepodporuje VBA. Pro zachování maker zvolte PPTM, PPSM nebo POTM.

**Může Aspose.Slides spouštět makra v prezentaci, například pro aktualizaci dat?**

Ne. Knihovna nikdy neprovádí kód VBA; provedení je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

**Je podpora práce s ActiveX ovládacími prvky propojenými s kódem VBA?**

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/java/activex/), upravovat jejich vlastnosti a odstraňovat je. To je užitečné, když makra komunikují s ActiveX.