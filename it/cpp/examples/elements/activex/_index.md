---
title: ActiveX
type: docs
weight: 200
url: /it/cpp/examples/elements/activex/
keywords:
- esempio di codice
- ActiveX
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Vedi esempi ActiveX di Aspose.Slides per C++: inserisci, configura e controlla gli oggetti ActiveX in presentazioni PPT e PPTX con codice C++ chiaro."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e configurare i controlli ActiveX in una presentazione utilizzando **Aspose.Slides for C++**.

## **Aggiungere un controllo ActiveX**

Inserisci un nuovo controllo ActiveX e, facoltativamente, imposta le sue proprietà.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Aggiungi un nuovo controllo ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Facoltativamente imposta alcune proprietà.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Accedere a un controllo ActiveX**

Leggi le informazioni dal primo controllo ActiveX nella diapositiva.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Accedi al primo controllo ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Rimuovere un controllo ActiveX**

Elimina un controllo ActiveX esistente dalla diapositiva.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Rimuovi il primo controllo ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Impostare le proprietà ActiveX**

Aggiungi un controllo e configura diverse proprietà ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Aggiungi un controllo Windows Media Player e configura le proprietà.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```