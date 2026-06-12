---
title: Správa VBA projektů v prezentacích v Androidu
linktitle: Prezentace pomocí VBA
type: docs
weight: 250
url: /cs/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Android v Javě generovat a upravovat prezentace PowerPoint a OpenDocument pomocí VBA a zefektivnit svůj pracovní postup."
---
## **Úvod**

Aspose.Slides poskytuje třídy a rozhraní pro práci s makry a kódem VBA.

{{% alert title="Poznámka" color="warning" %}} 

Když převedete prezentaci obsahující makra do jiného formátu souboru (PDF, HTML atd.), Aspose.Slides ignoruje všechna makra (makra nejsou přenesena do výsledného souboru).

Když přidáte makra do prezentace nebo znovu uložíte prezentaci obsahující makra, Aspose.Slides jednoduše zapíše bajty makr.

Aspose.Slides **nikdy** nespouští makra v prezentaci.

{{% /alert %}}

## **Přidání VBA makr**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/vbaproject/) umožňující vytvářet VBA projekty (a odkazy na projekty) a upravovat existující moduly. Můžete použít rozhraní [IVbaProject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivbaproject/) pro správu VBA vloženého v prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/vbaproject/#VbaProject--) k přidání nového VBA projektu.
1. Přidejte modul do VbaProject.
1. Nastavte zdrojový kód modulu.
1. Přidejte odkazy na <stdole>.
1. Přidejte odkazy na **Microsoft Office**.
1. Přiřaďte odkazy k VBA projektu.
1. Uložte prezentaci.

Tento Java kód ukazuje, jak přidat VBA makro od nuly do prezentace:

```java
// Vytvoří instanci třídy prezentace
Presentation pres = new Presentation();
try {
    // Vytvoří nový VBA projekt
    pres.setVbaProject(new VbaProject());
    
    // Přidá prázdný modul do VBA projektu
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Nastaví zdrojový kód modulu
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Vytvoří odkaz na <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Vytvoří odkaz na Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Přidá odkazy do VBA projektu
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Uloží prezentaci
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Můžete si prohlédnout **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), což je bezplatná webová aplikace používaná k odstraňování makr z dokumentů PowerPoint, Excel a Word. 

{{% /alert %}} 

## **Odstranění VBA makr**

Pomocí vlastnosti [VbaProject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getVbaProject--) pod třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) můžete odstranit VBA makro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci obsahující makro.
1. Získejte přístup k modulu Macro a odstraňte jej.
1. Uložte upravenou prezentaci.

Tento Java kód ukazuje, jak odstranit VBA makro:

```java
// Načte prezentaci obsahující makro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Přistoupí k Vba modulu a odstraní jej 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Uloží prezentaci
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahování VBA makr**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje VBA projekt.
3. Projděte všechny moduly obsažené v VBA projektu a zobrazte makra.

Tento Java kód ukazuje, jak extrahovat VBA makra z prezentace obsahující makra:

```java
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

Pomocí metody [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA project](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/vbaproject/).
3. Zkontrolujte, zda je VBA projekt chráněn heslem, abyste viděli jeho vlastnosti.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Zkontroluje, zda prezentace obsahuje VBA projekt.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Co se stane s makry, pokud uložím prezentaci jako PPTX?**

Makra budou odstraněna, protože PPTX nepodporuje VBA. Chcete-li makra zachovat, zvolte PPTM, PPSM nebo POTM.

**Může Aspose.Slides spouštět makra uvnitř prezentace, například pro obnovení dat?**

Ne. Knihovna nikdy nespouští VBA kód; spuštění je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

**Je podpora práce s ActiveX ovládacími prvky propojenými s VBA kódem?**

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/androidjava/activex/), upravovat jejich vlastnosti a odstraňovat je. To je užitečné, když makra komunikují s ActiveX.