---
title: Zarządzanie projektami VBA w prezentacjach na Androidzie
linktitle: Prezentacja za pomocą VBA
type: docs
weight: 250
url: /pl/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak generować i modyfikować prezentacje PowerPoint i OpenDocument przy użyciu VBA w Aspose.Slides dla Androida w Javie, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Aspose.Slides udostępnia klasy i interfejsy umożliwiające pracę z makrami i kodem VBA.

{{% alert title="Note" color="warning" %}} 

Kiedy konwertujesz prezentację zawierającą makra do innego formatu pliku (PDF, HTML itp.), Aspose.Slides ignoruje wszystkie makra (makra nie są przenoszone do powstałego pliku).

Gdy dodajesz makra do prezentacji lub ponownie zapisujesz prezentację zawierającą makra, Aspose.Slides po prostu zapisuje bajty makr.

Aspose.Slides **nigdy** nie uruchamia makr w prezentacji.

{{% /alert %}}

## **Dodaj makra VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/vbaproject/), która pozwala tworzyć projekty VBA (oraz odwołania do projektów) oraz edytować istniejące moduły. Możesz używać interfejsu [IVbaProject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivbaproject/), aby zarządzać VBA osadzonym w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/vbaproject/#VbaProject--) aby dodać nowy projekt VBA.
1. Dodaj moduł do VbaProject.
1. Ustaw kod źródłowy modułu.
1. Dodaj odwołania do <stdole>.
1. Dodaj odwołania do **Microsoft Office**.
1. Powiąż odwołania z projektem VBA.
1. Zapisz prezentację.

Ten kod w języku Java pokazuje, jak od podstaw dodać makro VBA do prezentacji:

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

Możesz sprawdzić **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), darmową aplikację internetową służącą do usuwania makr z dokumentów PowerPoint, Excel i Word.

{{% /alert %}} 

## **Usuń makra VBA**

Korzystając z właściwości [VbaProject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getVbaProject--) w klasie [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację zawierającą makro.
2. Uzyskaj dostęp do modułu Macro i usuń go.
3. Zapisz zmodyfikowaną prezentację.

Ten kod w języku Java pokazuje, jak usunąć makro VBA:

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

## **Wyodrębnij makra VBA**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera projekt VBA.
3. Iteruj po wszystkich modułach zawartych w projekcie VBA, aby wyświetlić makra.

Ten kod w języku Java pokazuje, jak wyodrębnić makra VBA z prezentacji zawierającej makra:

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

## **Sprawdź, czy projekt VBA jest chroniony hasłem**

Korzystając z metody [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--), możesz określić, czy właściwości projektu są chronione hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera [projekt VBA](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/vbaproject/).
3. Sprawdź, czy projekt VBA jest chroniony hasłem, aby zobaczyć jego właściwości.

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

Makra zostaną usunięte, ponieważ format PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, na przykład w celu odświeżenia danych?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; uruchamianie jest możliwe wyłącznie w programie PowerPoint przy odpowiednich ustawieniach zabezpieczeń.

**Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?**

Tak, możesz uzyskać dostęp do istniejących [kontrolek ActiveX](/slides/pl/androidjava/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.