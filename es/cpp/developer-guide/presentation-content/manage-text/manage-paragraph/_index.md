---
title: Administrar párrafos de texto de PowerPoint en C++
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/cpp/manage-paragraph/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades del párrafo
- importar HTML
- texto a HTML
- párrafo a HTML
- párrafo a imagen
- texto a imagen
- exportar párrafo
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domina el formato de párrafos con Aspose.Slides para C++ — optimiza alineación, espaciado y estilo en presentaciones PPT, PPTX y ODP en C++."
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y fragmentos de PowerPoint en C++.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) que le permite añadir objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) que le permite añadir objetos que representan fragmentos. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) que le permite añadir objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar varios párrafos que contienen múltiples porciones**

Estos pasos le muestran cómo agregar un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregue un rectángulo [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Obtenga el ITextFrame asociado con el [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) y agréguelos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y agregue cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establezca texto para cada porción.
8. Aplique las características de formato que prefiera a cada porción usando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceder a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregar un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Agregar TextFrame al Rectángulo
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

// Guardar PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Administrar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregue una [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame] de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Establezca el `Type` de viñeta del párrafo a `Symbol` y configure el carácter de viñeta.
8. Establezca el `Text` del párrafo.
9. Establezca la `Indent` del párrafo para la viñeta.
10. Establezca un color para la viñeta.
11. Establezca una altura para la viñeta.
12. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Agregue el segundo párrafo y repita el proceso descrito en los pasos 7 a 13.
14. Guarde la presentación.

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceder a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregar un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Agregar TextFrame al rectángulo
ashp->AddTextFrame(u"");

// Accediendo al marco de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Crear el objeto Paragraph para el marco de texto
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Establecer texto
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Establecer sangría de viñeta
paragraph->get_ParagraphFormat()->set_Indent (25);

// Establecer color de viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// establecer IsBulletHardColor a true para usar color de viñeta propio
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Establecer altura de la viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Agregar párrafo al marco de texto
txtFrame->get_Paragraphs()->Add(paragraph);

// Creando segundo párrafo
// Crear el objeto Paragraph para el marco de texto
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Establecer texto
paragraph2->set_Text(u"This is numbered bullet");

// Establecer tipo y estilo de viñeta del párrafo
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Establecer sangría de viñeta
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Establecer color de viñeta
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// establecer IsBulletHardColor a true para usar color de viñeta propio
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Establecer altura de la viñeta
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Agregar párrafo al marco de texto
txtFrame->get_Paragraphs()->Add(paragraph2);


// Guardar PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Administrar viñetas de imagen**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregue una [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame] de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta a [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) y configure la imagen.
9. Establezca el `Text` del Paragraph.
10. Establezca la `Indent` del Paragraph para la viñeta.
11. Establezca un color para la viñeta.
12. Establezca una altura para la viñeta.
13. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregue el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

```c++
// Instancia una clase Presentation que representa un archivo PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instancia la imagen para viñetas
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Añade y accede al Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al TextFrame del autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Elimina el párrafo predeterminado
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Crea un nuevo párrafo
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Establece el estilo de viñeta del párrafo y la imagen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Establece la altura de la viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Añade el párrafo al TextFrame
paragraphs->Add(paragraph);

// Guarda la presentación como archivo PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Guarda la presentación como archivo PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Administrar viñetas multinivel**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregue una [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame] de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) y establezca la profundidad a 0.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 1.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 2.
9. Cree la cuarta instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 3.
10. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

```c++
// Instancia una clase Presentation que representa un archivo PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Añade y accede al AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al marco de texto del AutoShape creado
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Limpia el párrafo predeterminado
text->get_Paragraphs()->Clear();

// Añade el primer párrafo
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de viñeta
para1Format->set_Depth(0);

// Añade el segundo párrafo
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de viñeta
para2Format->set_Depth(1);

// Añade el tercer párrafo
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de viñeta
para3Format->set_Depth(2);

// Añade el cuarto párrafo
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Establece el nivel de viñeta
para4Format->set_Depth(3);

// Añade los párrafos a la colección
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Guarda la presentación como archivo PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Administrar un párrafo con una lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) y otras que le permiten administrar párrafos con numeración o formato personalizados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Agregue una [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame] de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) a 2.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 3.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 7.
9. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al marco de texto del autoshape creado
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Elimina el párrafo predeterminado existente
textFrame->get_Paragraphs()->RemoveAt(0);

// Primera lista
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
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
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregue una [autoshape] rectangular a la diapositiva.
4. Agregue un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) con tres párrafos al autoshape rectangular.
5. Oculte las líneas del rectángulo.
6. Establezca la sangría para cada [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) a través de su propiedad BulletOffset.
7. Guarde la presentación modificada como un archivo PPT.

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceder a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregar un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Agregar TextFrame al rectángulo
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Agregar el primer párrafo
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"SlideTitle");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// Agregar el primer párrafo
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

//Agregar al marco de texto
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Guardar PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Establecer sangría colgante para un párrafo**

Este código C++ le muestra cómo establecer la sangría colgante para un párrafo:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Example");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Set Hanging Indent for Paragraph");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"This C# code shows you how to set the hanging indent for a paragraph: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Administrar propiedades de final de párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de la diapositiva que contiene el párrafo mediante su posición.
3. Agregue una [autoshape] rectangular a la diapositiva.
4. Agregue un [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) con dos párrafos al rectángulo.
5. Establezca el `FontHeight` y el tipo de fuente para los párrafos.
6. Establezca las propiedades End para los párrafos.
7. Guarde la presentación modificada como un archivo PPTX.

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceder a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregar un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Agregar TextFrame al rectángulo
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Añadiendo el primer párrafo
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Añadiendo el segundo párrafo
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Guardar PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Importar texto HTML en párrafos**

Aspose.Slides proporciona soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregue una [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Agregue y acceda al `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
5. Elimine el párrafo predeterminado en el `ITextFrame`.
6. Lea el archivo HTML fuente en un TextReader.
7. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
8. Agregue el contenido del archivo HTML leído al TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// La ruta al directorio de documentos.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceder a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agregar un AutoShape de tipo Rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Restableciendo el color de relleno predeterminado
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Agregar TextFrame al Rectángulo
ashp->AddTextFrame(u" ");

// Accediendo al marco de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Obtener colección de párrafos
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Limpiando todos los párrafos del marco de texto agregado
ParaCollection->Clear();

// Cargando el archivo HTML usando StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Añadiendo texto del StreamReader HTML al marco de texto
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Crear el objeto Paragraph para el marco de texto
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Crear objeto Portion para el párrafo
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Obtener formato de porción
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

// Guardar PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Exportar texto de párrafo a HTML**

Aspose.Slides proporciona soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a la forma que contiene el texto que se exportará a HTML.
4. Acceda al [TextFrame] de la forma.
5. Cree una instancia de `StreamWriter` y añada el nuevo archivo HTML.
6. Proporcione un índice inicial a `StreamWriter` y exporte los párrafos que prefiera.

```c++
// For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// La ruta al directorio de documentos.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Acceder a la primera diapositiva predeterminada de la presentación
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Índice deseado
int index = 0;

// Accediendo a la forma agregada
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extrayendo el primer párrafo como HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Escribiendo datos de párrafos a HTML proporcionando el índice de inicio del párrafo y el total de párrafos a copiar
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```


## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la interfaz [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/), como una imagen. Ambos ejemplos incluyen la obtención de la imagen de una forma que contiene el párrafo mediante los métodos `GetImage` de la interfaz [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), el cálculo de los límites del párrafo dentro de la forma y su exportación como imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones de PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil para su uso posterior en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el cuadro de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen separada manteniendo las dimensiones y el formato exactos del texto.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```


El resultado:

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan teniendo en cuenta la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para su uso en materiales impresos de alta calidad.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```


## **FAQ**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Use el método de ajuste del marco de texto ([set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)) para desactivar el ajuste, de modo que las líneas no se quiebren en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede obtener el rectángulo delimitador del párrafo (e incluso de una sola porción) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_alignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato de cada porción.

**¿Puedo establecer un idioma de revisión ortográfica solo para una parte de un párrafo (p. ej., una palabra)?**

Sí. El idioma se establece a nivel de porción usando ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)), por lo que varios idiomas pueden coexistir dentro de un mismo párrafo.