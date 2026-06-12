---
title: Gestire i connettori nelle presentazioni usando C++
linktitle: Connettore
type: docs
weight: 10
url: /it/cpp/connector/
keywords:
- connettore
- tipo di connettore
- punto del connettore
- linea del connettore
- angolo del connettore
- collegare forme
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Consenti alle app C++ di disegnare, collegare e instradare automaticamente le linee nelle diapositive PowerPoint—ottieni il pieno controllo sui connettori diritti, a gomito e curvi."
---
## **Introduzione**

Un connettore PowerPoint è una linea speciale che collega due forme tra loro e rimane attaccata alle forme anche quando vengono spostate o riposizionate su una diapositiva.  

I connettori sono tipicamente collegati a *punti di connessione* (punti verdi), presenti di default su tutte le forme. I punti di connessione appaiono quando il cursore si avvicina.  

*Punti di regolazione* (punti arancioni), presenti solo su alcuni connettori, sono usati per modificare la posizione e la forma dei connettori.  

## **Tipi di connettori**

In PowerPoint, è possibile utilizzare connettori diritti, a gomito (angolati) e curvi.  

Aspose.Slides fornisce questi connettori:

| Connettore                      | Immagine                                                        | Numero di punti di regolazione |
| ------------------------------ | --------------------------------------------------------------- | ------------------------------ |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Collegare forme usando i connettori**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/) .
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Aggiungi due [AutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.auto_shape) alla diapositiva usando il metodo `AddAutoShape` esposto dall'oggetto `Shapes`.
1. Aggiungi un connettore usando il metodo `AddConnector` esposto dall'oggetto `Shapes` definendo il tipo di connettore.
1. Collega le forme usando il connettore. 
1. Chiama il metodo `Reroute` per applicare il percorso di connessione più breve.
1. Salva la presentazione. 

Questo codice C++ mostra come aggiungere un connettore (un connettore a gomito) tra due forme (un'ellisse e un rettangolo):

```c++
// Il percorso alla directory dei documenti.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carica la presentazione desiderata
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede alla prima diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accede alla collezione di forme per una diapositiva specifica
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Aggiunge una forma automatica Ellisse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Aggiunge una forma automatica Rettangolo
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Aggiunge una forma connettore alla collezione di forme della diapositiva
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Collega le forme usando il connettore
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Chiama Reroute che imposta il percorso più breve automatico tra le forme
	connector->Reroute();
	
	// Salva la presentazione
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

Il metodo `connector->Reroute` riorienta un connettore e lo costringe a prendere il percorso più breve possibile tra le forme. Per raggiungere questo obiettivo, il metodo può modificare i punti `StartShapeConnectionSiteIndex` e `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Specificare un punto di connessione**

Se vuoi che un connettore leghi due forme usando punti specifici sulle forme, devi specificare i punti di connessione preferiti in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/) .
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Aggiungi due  [AutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.auto_shape) alla diapositiva usando il metodo `AddAutoShape` esposto dall'oggetto `Shapes`.
1. Aggiungi un connettore usando il metodo `AddConnector` esposto dall'oggetto `Shapes` definendo il tipo di connettore.
1. Collega le forme usando il connettore. 
1. Imposta i punti di connessione preferiti sulle forme. 
1. Salva la presentazione.

Questo codice C++ dimostra un'operazione in cui viene specificato un punto di connessione preferito:

```c++
	// Il percorso alla directory dei documenti.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carica la presentazione desiderata
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede alla prima diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accede alla collezione di forme per una diapositiva specifica
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Aggiunge una forma automatica Ellisse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Aggiunge una forma automatica Rettangolo
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Aggiunge una forma connettore alla collezione di forme della diapositiva
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Collega le forme usando il connettore
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Imposta l'indice del punto di connessione preferito sulla forma Ellisse
	int wantedIndex = 6;

	// Verifica se l'indice preferito è inferiore al numero massimo di punti di connessione
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Imposta il punto di connessione preferito sulla forma automatica Ellisse
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Salva la presentazione
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Regolare un punto del connettore**

È possibile regolare un connettore esistente tramite i suoi punti di regolazione. Solo i connettori con punti di regolazione possono essere modificati in questo modo. Vedi la tabella in **[Tipi di connettori.](/slides/it/cpp/connector/#types-of-connectors)** 

### **Caso semplice**

Considera un caso in cui un connettore tra due forme (A e B) passa attraverso una terza forma (C):

![connector-obstruction](connector-obstruction.png)

Codice:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Per evitare o aggirare la terza forma, possiamo regolare il connettore spostando la sua linea verticale verso sinistra in questo modo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Casi complessi** 

Per eseguire regolazioni più complesse, devi tenere conto di queste cose:

* Il punto regolabile di un connettore è fortemente legato a una formula che calcola e determina la sua posizione. Pertanto, le modifiche alla posizione del punto possono alterare la forma del connettore.
* I punti di regolazione di un connettore sono definiti in un ordine rigoroso in un array. I punti di regolazione sono numerati dal punto di inizio del connettore a quello di fine.
* I valori dei punti di regolazione riflettono la percentuale della larghezza/altezza della forma del connettore. 
  * La forma è delimitata dai punti di inizio e fine del connettore moltiplicati per 1000. 
  * Il primo punto, il secondo punto e il terzo punto definiscono rispettivamente la percentuale della larghezza, la percentuale dell'altezza e nuovamente la percentuale della larghezza. 
* Per i calcoli che determinano le coordinate dei punti di regolazione di un connettore, è necessario considerare la rotazione del connettore e il suo riflesso. **Nota** che l'angolo di rotazione per tutti i connettori mostrati sotto **[Tipi di connettori](/slides/it/cpp/connector/#types-of-connectors)** è 0.

#### **Caso 1**

Considera un caso in cui due oggetti di riquadro di testo sono collegati tra loro tramite un connettore:

![connector-shape-complex](connector-shape-complex.png)

Codice:

```c++
// Istanzia una classe di presentazione che rappresenta un file PPTX
auto pres = System::MakeObject<Presentation>();
// Ottiene la prima diapositiva nella presentazione
auto slide = pres->get_Slides()->idx_get(0);
// Ottiene le forme dalla prima diapositiva
auto shapes = slide->get_Shapes();
// Aggiunge forme che saranno unite tramite un connettore
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Aggiunge un connettore
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Specifica la direzione del connettore
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Specifica lo spessore della linea del connettore
lineFormat->set_Width(3);
// Specifica il colore del connettore
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Collega le forme insieme con il connettore
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Ottiene i punti di regolazione per il connettore
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Regolazione**

Possiamo modificare i valori dei punti di regolazione del connettore aumentando rispettivamente la percentuale di larghezza e di altezza del 20% e del 200%:

```c++
// Modifica i valori dei punti di regolazione
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Il risultato:

![connector-adjusted-1](connector-adjusted-1.png)

Per definire un modello che ci permetta di determinare le coordinate e la forma delle singole parti del connettore, creiamo una forma che corrisponda alla componente orizzontale del connettore al punto `connector.Adjustments[0]`:

```c++
// Disegna la componente verticale del connettore
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Il risultato:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

Nel **Caso 1**, abbiamo mostrato un'operazione semplice di regolazione del connettore usando principi di base. In situazioni normali, è necessario considerare la rotazione del connettore e la sua visualizzazione (impostate da `connector.Rotation`, `connector.Frame.FlipH` e `connector.Frame.FlipV`). Ora dimostreremo il processo.

Prima, aggiungiamo un nuovo oggetto di riquadro di testo (**To 1**) alla diapositiva (per scopi di connessione) e creiamo un nuovo connettore (verde) che lo collega agli oggetti già creati.

```c++
// Crea un nuovo oggetto di binding
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Crea un nuovo connettore
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Collega gli oggetti usando il connettore appena creato
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Ottiene i punti di regolazione del connettore
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Modifica i valori dei punti di regolazione
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Il risultato:

![connector-adjusted-3](connector-adjusted-3.png)

Secondo, creiamo una forma che corrisponda alla componente orizzontale del connettore che passa attraverso il nuovo punto di regolazione del connettore `connector.Adjustments[0]`. Useremo i valori dei dati del connettore per `connector.Rotation`, `connector.Frame.FlipH` e `connector.Frame.FlipV` e applicheremo la nota formula di conversione delle coordinate per la rotazione intorno a un punto dato x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Nel nostro caso, l'angolo di rotazione dell'oggetto è 90 gradi e il connettore è visualizzato verticalmente, quindi questo è il codice corrispondente:

```c++

```

Il risultato:

![connector-adjusted-4](connector-adjusted-4.png)

Abbiamo dimostrato calcoli che coinvolgono regolazioni semplici e punti di regolazione complessi (punti di regolazione con angoli di rotazione). Con le conoscenze acquisite, puoi sviluppare il tuo modello (o scrivere del codice) per ottenere un oggetto `GraphicsPath` o persino impostare i valori dei punti di regolazione di un connettore basati su coordinate specifiche della diapositiva.

## **Trovare l'angolo delle linee del connettore**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/) .
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi alla forma della linea del connettore.
4. Usa la larghezza, l'altezza, l'altezza del frame della forma e la larghezza del frame della forma per calcolare l'angolo.

Questo codice C++ dimostra un'operazione in cui abbiamo calcolato l'angolo per una forma di linea del connettore:

```c++
void ConnectorLineAngle()
{

	// Il percorso alla directory dei documenti.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carica la presentazione desiderata
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accede alla prima diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Accede alla collezione di forme delle diapositive
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **FAQ**

**Come posso capire se un connettore può essere "incollato" a una forma specifica?**

Verifica che la forma esponga i [punti di connessione](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/get_connectionsitecount/). Se non ci sono o il conteggio è zero, l'incollaggio non è disponibile; in tal caso, usa estremità libere e posizionale manualmente. È consigliabile controllare il conteggio dei punti prima di collegare.

**Cosa succede a un connettore se elimino una delle forme collegate?**

Le sue estremità verranno scollegate; il connettore rimane sulla diapositiva come una linea ordinaria con inizio/fine liberi. Puoi eliminarlo oppure riassegnare le connessioni e, se necessario, [reroute](https://reference.aspose.com/slides/it/cpp/aspose.slides/connector/reroute/).

**I legami dei connettori vengono mantenuti quando si copia una diapositiva in un'altra presentazione?**

In generale sì, a condizione che anche le forme di destinazione vengano copiate. Se la diapositiva viene inserita in un altro file senza le forme collegate, le estremità diventano libere e dovrai ricollegarle.