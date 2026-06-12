---
title: Správa projektů VBA v prezentacích pomocí PHP
linktitle: Prezentace přes VBA
type: docs
weight: 250
url: /cs/php-java/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- přidat makro
- odebrat makro
- extrahovat makro
- přidat VBA
- odebrat VBA
- extrahovat VBA
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, jak pomocí VBA generovat a manipulovat s prezentacemi PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java a zefektivnit tak svůj pracovní postup."
---
## **Úvod**

API Aspose.Slides obsahuje třídy pro práci s makry a kódem VBA.

{{% alert title="Note" color="warning" %}} 

Když převedete prezentaci obsahující makra do jiného formátu souboru (PDF, HTML atd.), Aspose.Slides ignoruje všechna makra (makra nejsou přenesena do výsledného souboru).

Když přidáte makra do prezentace nebo znovu uložíte prezentaci obsahující makra, Aspose.Slides jednoduše zapíše bajty makr.

Aspose.Slides **nikdy** nespouští makra v prezentaci.

{{% /alert %}}

## **Přidání VBA maker**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/vbaproject/), která vám umožní vytvářet projekty VBA (a odkazy na projekty) a upravovat existující moduly. Třídu `VbaProject` můžete použít ke správě VBA vloženého v prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Použijte konstruktor třídy [VbaProject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/vbaproject/#VbaProject) k přidání nového projektu VBA.
1. Přidejte modul do VbaProject.
1. Nastavte zdrojový kód modulu.
1. Přidejte odkazy na <stdole>.
1. Přidejte odkazy na **Microsoft Office**.
1. Přiřaďte odkazy k projektu VBA.
1. Uložte prezentaci.

Tento PHP kód vám ukazuje, jak od nuly přidat VBA makro do prezentace:

```php
  # Vytvoří instanci třídy prezentace
  $pres = new Presentation();
  try {
    # Vytvoří nový projekt VBA
    $pres->setVbaProject(new VbaProject());
    # Přidá prázdný modul do projektu VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Nastaví zdrojový kód modulu
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Vytvoří odkaz na <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Vytvoří odkaz na Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Přidá odkazy do projektu VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Uloží prezentaci
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Možná budete chtít vyzkoušet **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), což je bezplatná webová aplikace sloužící k odstranění maker z dokumentů PowerPoint, Excel a Word. 

{{% /alert %}} 

## **Odstranění VBA maker**

Pomocí vlastnosti [VbaProject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getVbaProject) v třídě [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) můžete makro VBA odstranit.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci obsahující makro.
1. Získejte přístup k modulu makra a odeberte jej.
1. Uložte upravenou prezentaci.

Tento PHP kód vám ukazuje, jak odstranit VBA makro:

```php
  # Načte prezentaci obsahující makro
  $pres = new Presentation("VBA.pptm");
  try {
    # Získá přístup k Vba modulu a odebere jej
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Uloží prezentaci
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extrahování VBA maker**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje projekt VBA.
3. Projděte všechny moduly obsažené v projektu VBA a zobrazte makra.

Tento PHP kód vám ukazuje, jak extrahovat VBA makra z prezentace obsahující makra:

```php
  # Načte prezentaci obsahující makro
  $pres = new Presentation("VBA.pptm");
  try {
    # Kontroluje, zda prezentace obsahuje projekt VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kontrola, zda je projekt VBA chráněn heslem**

Použitím metody [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/vbaproject/#isPasswordProtected) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA projekt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/vbaproject/).
3. Zkontrolujte, zda je projekt VBA chráněn heslem, abyste mohli zobrazit jeho vlastnosti.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Zkontroluje, zda prezentace obsahuje projekt VBA.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Často kladené dotazy**

**Co se stane s makry, pokud uložíte prezentaci jako PPTX?**

Makra budou odstraněna, protože PPTX nepodporuje VBA. Chcete‑li zachovat makra, zvolte PPTM, PPSM nebo POTM.

**Může Aspose.Slides spouštět makra v prezentaci, například pro obnovení dat?**

Ne. Knihovna nikdy nevykonává kód VBA; jeho spuštění je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

**Je podpora práce s ovládacími prvky ActiveX propojenými s kódem VBA?**

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/php-java/activex/), měnit jejich vlastnosti a odstraňovat je. To je užitečné, když makra komunikují s ActiveX.