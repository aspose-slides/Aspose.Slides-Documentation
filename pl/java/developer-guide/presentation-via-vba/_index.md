---
title: Zarządzanie projektami VBA w prezentacjach przy użyciu Javy
linktitle: Prezentacja przez VBA
type: docs
weight: 250
url: /pl/java/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- dodaj makro
- usuń makro
- wyodrębnij makro
- dodaj VBA
- usuń VBA
- wyodrębnij VBA
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak generować i modyfikować prezentacje PowerPoint i OpenDocument przy użyciu VBA z Aspose.Slides dla Javy, aby usprawnić swój proces pracy."
---
## **Wprowadzenie**

Aspose.Slides udostępnia klasy i interfejsy do pracy z makrami i kodem VBA.

{{% alert title="Note" color="warning" %}} 

Podczas konwertowania prezentacji zawierającej makra do innego formatu pliku (PDF, HTML itp.), Aspose.Slides ignoruje wszystkie makra (makra nie są przenoszone do wynikowego pliku).

Gdy dodajesz makra do prezentacji lub ponownie zapisujesz prezentację zawierającą makra, Aspose.Slides po prostu zapisuje bajty makr.

Aspose.Slides **nigdy** nie uruchamia makr w prezentacji.

{{% /alert %}}

## **Dodawanie makr VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/vbaproject/) umożliwiającą tworzenie projektów VBA (i odwołań do projektów) oraz edycję istniejących modułów. Możesz użyć interfejsu [IVbaProject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivbaproject/) do zarządzania VBA osadzonym w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) .
2. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/vbaproject/#VbaProject--) aby dodać nowy projekt VBA.
3. Dodaj moduł do VbaProject.
4. Ustaw kod źródłowy modułu.
5. Dodaj odwołania do <stdole>.
6. Dodaj odwołania do **Microsoft Office**.
7. Powiąż odwołania z projektem VBA.
8. Zapisz prezentację.

Ten kod Java pokazuje, jak od podstaw dodać makro VBA do prezentacji:

```java
// Tworzy instancję klasy prezentacji
Presentation pres = new Presentation();
try {
    // Tworzy nowy projekt VBA
    pres.setVbaProject(new VbaProject());
    
    // Dodaje pusty moduł do projektu VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Ustawia kod źródłowy modułu
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Tworzy odwołanie do <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Tworzy odwołanie do Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Dodaje odwołania do projektu VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Zapisuje prezentację
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Możesz sprawdzić **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), który jest darmową aplikacją internetową służącą do usuwania makr z dokumentów PowerPoint, Excel i Word. 

{{% /alert %}} 

## **Usuwanie makr VBA**

Korzystając z właściwości [VbaProject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getVbaProject--) w klasie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) i załaduj prezentację zawierającą makro.
2. Uzyskaj dostęp do modułu Macro i usuń go.
3. Zapisz zmodyfikowaną prezentację.

Ten kod Java pokazuje, jak usunąć makro VBA:

```java
// Ładuje prezentację zawierającą makro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Uzyskuje dostęp do modułu Vba i usuwa go 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Zapisuje prezentację
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyodrębnianie makr VBA**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) i załaduj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera projekt VBA.
3. Iteruj po wszystkich modułach zawartych w projekcie VBA, aby zobaczyć makra.

Ten kod Java pokazuje, jak wyodrębnić makra VBA z prezentacji zawierającej makra:

```java
// Ładuje prezentację zawierającą makro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Sprawdza, czy prezentacja zawiera projekt VBA
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

## **Sprawdzenie, czy projekt VBA jest chroniony hasłem**

Korzystając z metody [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) możesz ustalić, czy właściwości projektu są chronione hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i załaduj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera [VBA project](https://reference.aspose.com/slides/pl/java/com.aspose.slides/vbaproject/).
3. Sprawdź, czy projekt VBA jest chroniony hasłem, aby wyświetlić jego właściwości.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Sprawdź, czy prezentacja zawiera projekt VBA.
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

**Co się dzieje z makrami, jeśli zapiszę prezentację jako PPTX?**

Makra zostaną usunięte, ponieważ PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, aby na przykład odświeżyć dane?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; wykonywanie jest możliwe tylko w PowerPoint przy odpowiednich ustawieniach zabezpieczeń.

**Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?**

Tak, możesz uzyskać dostęp do istniejących [ActiveX controls](/slides/pl/java/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.