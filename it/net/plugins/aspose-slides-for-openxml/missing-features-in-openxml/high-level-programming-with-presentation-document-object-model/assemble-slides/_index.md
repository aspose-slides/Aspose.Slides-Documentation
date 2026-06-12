---
title: Assemblare Diapositive
type: docs
weight: 10
url: /it/net/assemble-slides/
---
## **Aggiungere una diapositiva a una presentazione**
Prima di parlare dell'aggiunta di diapositive ai file di presentazione, discutiamo alcuni fatti sulle diapositive. Ogni file di presentazione PowerPoint contiene una diapositiva Master / Layout e altre diapositive Normali. Ciò significa che un file di presentazione contiene almeno una o più diapositive. È importante sapere che i file di presentazione senza diapositive non sono supportati da Aspose.Slides per .NET. Ogni diapositiva ha un Id univoco e tutte le Diapositive Normali sono disposte in un ordine specificato dall'indice basato su zero.

Aspose.Slides per .NET consente agli sviluppatori di aggiungere diapositive vuote alla loro presentazione. Per aggiungere una diapositiva vuota nella presentazione, seguire i passaggi seguenti:

- Creare un'istanza della classe **Presentation**
- Istanziare la classe **SlideCollection** impostando un riferimento alla proprietà Slides (collezione di oggetti Slide di contenuto) esposta dall'oggetto Presentation.
- Aggiungere una diapositiva vuota alla presentazione alla fine della collezione di diapositive di contenuto chiamando i metodi **AddEmptySlide** esposti dall'oggetto **SlideCollection**
- Eseguire alcune operazioni con la diapositiva vuota appena aggiunta
- Infine, scrivere il file di presentazione usando l'oggetto **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//Instanzia la classe SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Aggiungi una diapositiva vuota alla collezione Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Salva il file PPTX sul disco

pres.Write("EmptySlide.pptx");

``` 
## **Accedere alle diapositive di una presentazione**
Aspose.Slides per .NET fornisce la classe Presentation che può essere utilizzata per trovare e accedere a qualsiasi diapositiva desiderata presente nella presentazione.

**Utilizzo della collezione Slides**

La classe **Presentation** rappresenta un file di presentazione ed espone tutte le diapositive in esso come una collezione **SlideCollection** (che è una collezione di oggetti **Slide**). Tutte queste diapositive possono essere accedute da questa collezione **Slides** usando un indice di diapositiva.

``` csharp

 //Istanzia un oggetto Presentation che rappresenta un file di presentazione

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accesso a una diapositiva usando il suo indice di diapositiva

SlideEx slide = pres.Slides[0];

``` 
## **Rimuovere diapositive**
Sappiamo che la classe Presentation in **Aspose.Slides per .NET** rappresenta un file di presentazione. La classe Presentation incapsula una **SlideCollection** che funge da repository di tutte le diapositive che fanno parte della presentazione. Gli sviluppatori possono rimuovere una diapositiva da questa collezione Slides in due modi:

- Utilizzando il riferimento alla diapositiva
- Utilizzando l'indice della diapositiva

**Utilizzando il riferimento alla diapositiva**

Per rimuovere una diapositiva usando il suo riferimento, seguire i passaggi seguenti:

- Creare un'istanza della classe Presentation
- Ottenere il riferimento di una diapositiva usando il suo Id o indice
- Rimuovere la diapositiva di riferimento dalla presentazione
- Scrivere il file di presentazione modificato

``` csharp

 //Instanzia un oggetto Presentation che rappresenta un file di presentazione

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accesso a una diapositiva usando il suo indice nella collezione di diapositive

SlideEx slide = pres.Slides[0];

//Rimozione di una diapositiva usando il suo riferimento

pres.Slides.Remove(slide);

//Scrittura del file di presentazione

pres.Write("modified.pptx");

``` 
## **Modificare la posizione di una diapositiva**
È molto semplice modificare la posizione di una diapositiva nella presentazione. Basta seguire i passaggi seguenti:

- Creare un'istanza della classe Presentation
- Ottenere il riferimento di una diapositiva usando il suo indice
- Modificare il valore SlideNumber della diapositiva di riferimento
- Scrivere il file di presentazione modificato

Nell'esempio riportato di seguito, abbiamo modificato la posizione di una diapositiva (situata all'indice zero posizione 1) della presentazione) all'indice 1 (Posizione 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Instanzia la classe SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Aggiungi una diapositiva vuota alla collezione Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Salva il file PPTX sul disco

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instanzia un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accesso a una diapositiva usando il suo indice di diapositiva

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instanzia un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accesso a una diapositiva usando il suo indice nella collezione di diapositive

ISlide slide = pres.Slides[0];

//Rimozione di una diapositiva usando il suo riferimento

pres.Slides.Remove(slide);

//Scrittura del file di presentazione

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instanzia la classe Presentation per caricare il file di presentazione sorgente

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Ottieni la diapositiva la cui posizione deve essere cambiata

    ISlide sld = pres.Slides[0];

    //Imposta la nuova posizione per la diapositiva

    sld.SlideNumber = 2;

    //Scrivi la presentazione su disco

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Scaricare il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)