---
title: Gestionar párrafos de PowerPoint en C++
type: docs
weight: 40
url: /es/cpp/manage-paragraph/
keywords: "Añadir párrafo de PowerPoint, Gestionar párrafos, Sangrías de párrafo, Propiedades de párrafo, texto HTML, Exportar texto de párrafo, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Crear y gestionar párrafo, texto, sangría y propiedades en presentaciones de PowerPoint en C++"
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint en C++.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) para permitirle añadir objetos que representan un párrafo. Un objeto `ITextFrame` puede tener uno o varios párrafos (cada párrafo se crea a través de un salto de línea).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) para permitirle añadir objetos que representan porciones. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) para permitirle añadir objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de gestionar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar múltiples párrafos que contienen múltiples porciones**

Estos pasos le muestran cómo agregar un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) de tipo Rectángulo a la diapositiva.
4. Obtenga el ITextFrame asociado con la [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) y agréguellos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo por defecto) y agregue cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establezca algún texto para cada porción.
8. Aplique sus características de formato preferidas a cada porción utilizando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

Este código en C++ es una implementación de los pasos para agregar párrafos que contienen porciones:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Cargue la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceda a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregue un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Agregue TextFrame al Rectángulo
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accediendo al primer párrafo
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Agregando segundo párrafo
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Agregando tercer párrafo
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Guardar PPTX en Disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Gestionar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con viñetas son siempre más fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) del autoshape.
5. Elimine el párrafo por defecto en el `TextFrame`.
6. Cree la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Establezca el `Type` de la viñeta para el párrafo a `Symbol` y establezca el carácter de viñeta.
8. Establezca el `Text` del párrafo.
9. Establezca la `Indent` del párrafo para la viñeta.
10. Establezca un color para la viñeta.
11. Establezca una altura para la viñeta.
12. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Agregue el segundo párrafo y repita el proceso dado en los pasos 7 a 13.
14. Guarde la presentación.

Este código C++ le muestra cómo agregar una viñeta de párrafo:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Cargue la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceda a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregue un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Agregue TextFrame al Rectángulo
ashp->AddTextFrame(u"");

// Accediendo al marco de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Cree el objeto Paragraph para el marco de texto
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Estableciendo Texto
paragraph->set_Text(u"Bienvenido a Aspose.Slides");

// Estableciendo sangría de viñeta
paragraph->get_ParagraphFormat()->set_Indent (25);

// Estableciendo color de viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// establecer IsBulletHardColor en verdadero para usar el color de viñeta propio
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Estableciendo Altura de viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Agregando párrafo al marco de texto
txtFrame->get_Paragraphs()->Add(paragraph);

// Creando segundo párrafo
// Cree el objeto Paragraph para el marco de texto
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Estableciendo Texto
paragraph2->set_Text(u"Este es un viñeta numerada");

// Estableciendo tipo y estilo de viñeta del párrafo
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Estableciendo sangría de viñeta
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Estableciendo color de viñeta
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// establecer IsBulletHardColor en verdadero para usar el color de viñeta propio
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Estableciendo Altura de viñeta
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Agregando párrafo al marco de texto
txtFrame->get_Paragraphs()->Add(paragraph2);


// Guardar PPTX en Disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Gestionar viñetas de imagen**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con imágenes son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) del autoshape. 
5. Elimine el párrafo por defecto en el `TextFrame`.
6. Cree la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta a [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) y establezca la imagen.
9. Establezca el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Establezca un color para la viñeta.
12. Establezca una altura para la viñeta.
13. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregue el segundo párrafo y repita el proceso con base en los pasos anteriores.
15. Guarde la presentación modificada.

Este código C++ le muestra cómo agregar y gestionar viñetas de imagen:

```c++
// Instancia una clase Presentation que representa un archivo PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instancia la imagen para viñetas
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Agrega y accede a Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al textframe del autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Elimina el párrafo por defecto
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Crea un nuevo párrafo
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Bienvenido a Aspose.Slides");

// Establece el estilo de viñeta del párrafo y la imagen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Establece la Altura de la viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Agrega el párrafo al marco de texto
paragraphs->Add(paragraph);

// Escribe la presentación como un archivo PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Escribe la presentación como un archivo PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Gestionar viñetas multinivel**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Las viñetas multinivel son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) del autoshape. 
5. Elimine el párrafo por defecto en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) y establezca la profundidad en 0.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 1.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 2.
9. Cree la cuarta instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 3.
10. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

Este código C++ le muestra cómo agregar y gestionar viñetas multinivel:

```c++
// Instancia una clase Presentation que representa un archivo PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Agrega y accede a Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al marco de texto del autoshape creado
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Limpia el párrafo por defecto
text->get_Paragraphs()->Clear();

// Agrega el primer párrafo
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Contenido");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de la viñeta
para1Format->set_Depth(0);

// Agrega el segundo párrafo
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Segundo Nivel");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de la viñeta
para2Format->set_Depth(1);

// Agrega el tercer párrafo
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Tercer Nivel");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de la viñeta
para3Format->set_Depth(2);

// Agrega el cuarto párrafo
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Cuarto Nivel");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de la viñeta
para4Format->set_Depth(3);

// Agrega párrafos a la colección
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Escribe la presentación como un archivo PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Gestionar párrafo con lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) y otras que le permiten gestionar párrafos con numeración o formato personalizado.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Agregue un [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) del autoshape. 
5. Elimine el párrafo por defecto en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) a 2.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` a 3.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` a 7.
9. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

Este código C++ le muestra cómo agregar y gestionar párrafos con numeración o formato personalizado:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al marco de texto del autoshape creado
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Elimina el párrafo existente por defecto
textFrame->get_Paragraphs()->RemoveAt(0);

// Primer lista
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"viñeta 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"viñeta 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"viñeta 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **Establecer sangría de párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Acceda a la referencia de la diapositiva relevante a través de su índice.
1. Agregue un [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) de rectángulo a la diapositiva.
1. Agregue un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) con tres párrafos al autoshape de rectángulo.
1. Oculte las líneas del rectángulo.
1. Establezca la sangría para cada [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) a través de su propiedad BulletOffset.
1. Escriba la presentación modificada como un archivo PPT.

Este código C++ le muestra cómo establecer una sangría de párrafo: 

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Cargue la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceda a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregue un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Agregue TextFrame al Rectángulo
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Agregando el primer párrafo
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"Título de la diapositiva");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// Agregando el primer párrafo
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

// Agregando al marco de texto
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Guardar PPTX en Disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Establecer sangría colgante para el párrafo**

Este código C++ le muestra cómo establecer la sangría colgante para un párrafo:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Ejemplo");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Establecer sangría colgante para el párrafo");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Este código C++ le muestra cómo establecer la sangría colgante para un párrafo:");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Gestionar propiedades de impresión final para el párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Obtenga la referencia para la diapositiva que contiene el párrafo a través de su posición.
1. Agregue un [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Agregue un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) con dos párrafos al Rectángulo.
1. Establezca la `FontHeight` y el tipo de fuente para los párrafos.
1. Establezca las propiedades finales para los párrafos.
1. Escriba la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo establecer las propiedades finales para los párrafos en PowerPoint: 

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Cargue la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceda a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregue un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Agregue TextFrame al Rectángulo
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Agregando el primer párrafo
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Texto de ejemplo");

para1->get_Portions()->Add(port01);

// Agregando el segundo párrafo
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Texto de ejemplo 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Guardar PPTX en Disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Importar texto HTML en párrafos**

Aspose.Slides proporciona soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Agregue y acceda al `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. Elimine el párrafo por defecto en el `ITextFrame`.
6. Lea el archivo HTML fuente en un TextReader.
7. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) .
8. Agregue el contenido del archivo HTML leído en el TextReader a la colección [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

Este código C++ es una implementación de los pasos para importar textos HTML en párrafos: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// La ruta al directorio de documentos.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Cargue la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceda a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregue un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Restableciendo el color de relleno por defecto
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Agregue TextFrame al Rectángulo
ashp->AddTextFrame(u" ");

// Accediendo al marco de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Obtener la colección de párrafos
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Limpiar todos los párrafos en el marco de texto agregado
ParaCollection->Clear();

// Cargar el archivo HTML usando un lector de flujos
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Agregar texto del lector de flujo HTML en el marco de texto
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Crear el objeto Paragraph para el marco de texto
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Crear el objeto Portion para el párrafo
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Texto de Aspose");

// Obtener formato de porción
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Establecer la fuente para la porción
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Establecer la propiedad negrita de la fuente
pf->set_FontBold(NullableBool::True);

// Establecer la propiedad cursiva de la fuente
pf->set_FontItalic(NullableBool::True);

// Establecer la propiedad subrayado de la fuente
pf->set_FontUnderline(TextUnderlineType::Single);

// Establecer la altura de la fuente
pf->set_FontHeight(25);

// Establecer el color de la fuente
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Guardar PPTX en Disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Exportar texto de párrafos a HTML**

Aspose.Slides proporciona soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Acceda a la forma que contiene el texto que será exportado a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de la forma.
5. Cree una instancia de `StreamWriter` y agregue el nuevo archivo HTML.
6. Proporcione un índice inicial al StreamWriter y exporte sus párrafos preferidos.

Este código C++ le muestra cómo exportar textos de párrafos de PowerPoint a HTML: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// La ruta al directorio de documentos.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Cargue la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Acceder a la primera diapositiva por defecto de la presentación
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Índice deseado
int index = 0;

// Accediendo a la forma agregada
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extrayendo el primer párrafo como HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Escribir datos de párrafos en HTML proporcionando el índice inicial del párrafo, el total de párrafos a copiar
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```