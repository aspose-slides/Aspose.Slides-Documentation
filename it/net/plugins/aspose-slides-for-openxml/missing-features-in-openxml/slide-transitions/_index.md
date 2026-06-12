---
title: Transizioni delle diapositive
type: docs
weight: 80
url: /it/net/slide-transitions/
---
Per semplificare la comprensione, abbiamo dimostrato l'uso di Aspose.Slides per .NET per gestire transizioni diapositive semplici. Gli sviluppatori possono non solo applicare diversi effetti di transizione su diapositive, ma anche personalizzare il comportamento di questi effetti di transizione. Per creare un semplice effetto di transizione della diapositiva, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Applica un tipo di transizione della diapositiva sulla diapositiva da uno degli effetti di transizione offerti da Aspose.Slides per .NET tramite l'enum **TransitionType** enum
- Scrivi il file di presentazione modificato.
## **Esempio**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instanzia la classe Presentation che rappresenta un file di presentazione

using (Presentation pres = new Presentation(FileName))

{

    //Applica la transizione di tipo cerchio alla diapositiva 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Applica la transizione di tipo pettine alla diapositiva 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Applica la transizione di tipo zoom alla diapositiva 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Scrivi la presentazione su disco

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Scarica Esempio Operativo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

Per ulteriori dettagli, visita [Gestione delle Transizioni delle Diapositive](/slides/it/net/slide-transition/).

{{% /alert %}}