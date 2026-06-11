---
title: "Zarządzaj projektami VBA w prezentacjach przy użyciu JavaScript"
linktitle: "Prezentacja przy użyciu VBA"
type: docs
weight: 250
url: /pl/nodejs-java/presentation-via-vba/
keywords:
- "makro"
- "VBA"
- "makro VBA"
- "dodaj makro"
- "usuń makro"
- "wyodrębnij makro"
- "dodaj VBA"
- "usuń VBA"
- "wyodrębnij VBA"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Generuj i manipuluj prezentacjami PowerPoint i OpenDocument przy użyciu VBA w JavaScript z Aspose.Slides dla Node.js poprzez Java, aby usprawnić swój proces pracy."
---
## **Wprowadzenie**

Aspose.Slides udostępnia klasy do pracy z makrami i kodem VBA.

{{% alert title="Note" color="warning" %}} 

Kiedy konwertujesz prezentację zawierającą makra na inny format pliku (PDF, HTML itp.), Aspose.Slides ignoruje wszystkie makra (makra nie są przenoszone do powstałego pliku).

Kiedy dodajesz makra do prezentacji lub ponownie zapisujesz prezentację zawierającą makra, Aspose.Slides po prostu zapisuje bajty makr.

Aspose.Slides **nigdy** nie uruchamia makr w prezentacji.

{{% /alert %}}

## **Dodaj makra VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/vbaproject/), która pozwala tworzyć projekty VBA (i odwołania do projektów) oraz edytować istniejące moduły. Możesz używać klasy [VbaProject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/vbaproject/) do zarządzania VBA osadzonym w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/vbaproject/#VbaProject--) aby dodać nowy projekt VBA.
1. Dodaj moduł do VbaProject.
1. Ustaw kod źródłowy modułu.
1. Dodaj odwołania do <stdole>.
1. Dodaj odwołania do **Microsoft Office**.
1. Powiąż odwołania z projektem VBA.
1. Zapisz prezentację.

Ten kod JavaScript pokazuje, jak dodać makro VBA od podstaw do prezentacji:

```javascript
// Tworzy instancję klasy prezentacji
let pres = new aspose.slides.Presentation();
try {
    // Tworzy nowy projekt VBA
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Dodaje pusty moduł do projektu VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Ustawia kod źródłowy modułu
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Tworzy odwołanie do <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Tworzy odwołanie do Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Dodaje odwołania do projektu VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Zapisuje prezentację
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Być może zechcesz wypróbować **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), który jest darmową aplikacją internetową służącą do usuwania makr z dokumentów PowerPoint, Excel i Word.

{{% /alert %}} 

## **Usuń makra VBA**

Korzystając z właściwości [VbaProject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getVbaProject--) w klasie [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wczytaj prezentację zawierającą makro.
1. Uzyskaj dostęp do modułu Macro i usuń go.
1. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak usunąć makro VBA:

```javascript
// Ładuje prezentację zawierającą makro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Uzyskuje dostęp do modułu Vba i usuwa go
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Zapisuje prezentację
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Wyodrębnij makra VBA**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera projekt VBA.
3. Iteruj po wszystkich modułach zawartych w projekcie VBA, aby zobaczyć makra.

Ten kod JavaScript pokazuje, jak wyodrębnić makra VBA z prezentacji zawierającej makra:

```javascript
// Ładuje prezentację zawierającą makro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Sprawdza, czy prezentacja zawiera projekt VBA
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sprawdź, czy projekt VBA jest chroniony hasłem**

Korzystając z metody [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected), możesz określić, czy właściwości projektu są chronione hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera [projekt VBA](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/vbaproject/).
3. Sprawdź, czy projekt VBA jest chroniony hasłem, aby wyświetlić jego właściwości.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Sprawdź, czy prezentacja zawiera projekt VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Co się dzieje z makrami, jeśli zapisuję prezentację jako PPTX?**

Makra zostaną usunięte, ponieważ format PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, np. odświeżać dane?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; wykonywanie jest możliwe wyłącznie w PowerPoint z odpowiednimi ustawieniami zabezpieczeń.

**Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?**

Tak, możesz uzyskać dostęp do istniejących [kontrolek ActiveX](/slides/pl/nodejs-java/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.