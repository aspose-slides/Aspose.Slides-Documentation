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
description: "Domina el formato de párrafos con Aspose.Slides para C++—optimiza la alineación, el espaciado y el estilo en presentaciones PPT, PPTX y ODP en C++."
---
Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y fragmentos de PowerPoint en C++.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) para permitirle añadir objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/) para permitirle añadir objetos que representan fragmentos. Un objeto `IParagraph` puede tener uno o varios fragmentos (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/) para permitirle añadir objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato mediante sus objetos subyacentes `IPortion`.

## **Agregar varios párrafos que contienen varios fragmentos**

Estos pasos le muestran cómo añadir un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 fragmentos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Obtenga el ITextFrame asociado al [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/) y añádalos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y añada cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establezca algún texto para cada fragmento.
8. Aplique sus características de formato preferidas a cada fragmento usando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acceder a la primera diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Añadir un AutoShape de tipo rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Añadir TextFrame al rectángulo
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accediendo al primer párrafo
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Añadiendo el segundo párrafo
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Añadiendo el tercer párrafo
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

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraph/).
7. Establezca el `Type` de la viñeta del párrafo a `Symbol` y defina el carácter de la viñeta.
8. Establezca el `Text` del párrafo.
9. Establezca el `Indent` del párrafo para la viñeta.
10. Defina un color para la viñeta.
11. Defina una altura para la viñeta.
12. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Añada el segundo párrafo y repita el proceso indicado en los pasos 7 a 13.
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

// Añadir un AutoShape de tipo rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Añadir TextFrame al rectángulo
ashp->AddTextFrame(u"");

// Accediendo al marco de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Crear el objeto Paragraph para el marco de texto
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Establecer texto
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Establecer sangría de viñeta
paragraph->get_ParagraphFormat()->set_Indent (25);

// Establecer color de viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// establecer IsBulletHardColor a true para usar el color propio de la viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Establecer altura de viñeta
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Añadiendo párrafo al marco de texto
txtFrame->get_Paragraphs()->Add(paragraph);

// Creando segundo párrafo
// Crear el objeto Paragraph para el marco de texto
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Establecer texto
paragraph2->set_Text(u"This is numbered bullet");

// Establecer tipo y estilo de viñeta del párrafo
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Establecer sangría de viñeta
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Establecer color de viñeta
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// establecer IsBulletHardColor a true para usar el color propio de la viñeta
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Establecer altura de viñeta
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Añadiendo párrafo al marco de texto
txtFrame->get_Paragraphs()->Add(paragraph2);


// Guardar PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Administrar viñetas con imágenes**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta a [Picture](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) y asigne la imagen.
9. Establezca el `Text` del Paragraph.
10. Establezca el `Indent` del Paragraph para la viñeta.
11. Defina un color para la viñeta.
12. Defina una altura para la viñeta.
13. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añada el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

```c++
// Instancia una clase Presentation que representa un archivo PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instancia la imagen para viñetas
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Añade y accede a Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al TextFrame de la autoshape
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

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph] y establezca la profundidad a 0.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 1.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 2.
9. Cree la cuarta instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 3.
10. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

```c++
// Instancia una clase Presentation que representa un archivo PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Añade y accede a Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al marco de texto del autoshape creado
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Elimina el párrafo predeterminado
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

// Escribe la presentación como archivo PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Administrar un párrafo con una lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) y otras que le permiten gestionar párrafos con numeración o formato personalizado.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph] y establezca [NumberedBulletStartWith] a 2.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 3.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 7.
9. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
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

## **Establecer sangría de primera línea para un párrafo**

Utilice el método [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) para controlar la sangría de la primera línea de un párrafo. Este método desplaza sólo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo mueve la primera línea a la derecha, mientras que el resto de líneas permanecen alineadas con el cuerpo del párrafo.

Utilice [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_marginleft/) cuando necesite mover todo el párrafo. Utilice [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) cuando necesite mover sólo la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de `Indent` para demostrar cómo la sangría de la primera línea afecta al diseño del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/textframe/) vacío a la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) para cada uno.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La sangría de primera línea de los párrafos](first_line_indent.png)

## **Establecer sangría colgante para un párrafo**

Una sangría colgante es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crea este efecto con el método [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/). Establezca la sangría a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_marginleft/) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo de `MarginLeft` y un valor negativo de `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas continuas deben alinearse bajo el cuerpo del párrafo en lugar de bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/textframe/) vacío a la forma y elimine el párrafo predeterminado.
5. Cree párrafos y establezca un valor positivo de [MarginLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_marginleft/) para cada párrafo.
6. Establezca un valor negativo de [Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) para crear el efecto de sangría colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La sangría colgante de los párrafos](hanging_indent.png)

## **Administrar propiedades finales del párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de la diapositiva que contiene el párrafo mediante su posición.
3. Añada un [autoshape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) con dos párrafos al rectángulo.
5. Establezca la `FontHeight` y el tipo de fuente para los párrafos.
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

// Añadir un AutoShape de tipo rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Añadir TextFrame al rectángulo
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

Aspose.Slides ofrece soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
4. Añada y acceda al [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) del `autoshape` 
5. Elimine el párrafo predeterminado en el `ITextFrame`.
6. Lea el archivo HTML origen con un TextReader.
7. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraph/).
8. Añada el contenido del archivo HTML leído con el TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraphcollection/) del TextFrame.
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

// Añadir un AutoShape de tipo rectángulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Restableciendo el color de relleno predeterminado
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Añadir TextFrame al rectángulo
ashp->AddTextFrame(u" ");

// Accediendo al marco de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Obtener la colección de párrafos
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Eliminando todos los párrafos del marco de texto añadido
ParaCollection->Clear();

// Cargando el archivo HTML mediante StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Añadiendo texto del StreamReader HTML al marco de texto
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Crear el objeto Paragraph para el marco de texto
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Crear objeto Portion para el párrafo
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Obtener el formato del fragmento
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Establecer la fuente para el fragmento
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

Aspose.Slides ofrece soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a la forma que contiene el texto que será exportado a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la forma.
5. Cree una instancia de `StreamWriter` y añada el nuevo archivo HTML.
6. Proporcione un índice inicial a StreamWriter y exporte los párrafos que prefiera.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// La ruta al directorio de documentos.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Acceder a la primera diapositiva predeterminada de la presentación
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Índice deseado
int index = 0;

// Accediendo a la forma añadida
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extrayendo el primer párrafo como HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Escribiendo datos de los párrafos en HTML proporcionando el índice de inicio del párrafo y el número total de párrafos a copiar
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la interfaz [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/), como una imagen. Ambos ejemplos incluyen obtener la imagen de una forma que contiene el párrafo usando los métodos `GetImage` de la interfaz [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/), calcular los límites del párrafo dentro de la forma y exportarlo como una imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil para utilizarlas posteriormente en varios escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen separada manteniendo las dimensiones y el formato exactos del texto.

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

![La imagen del párrafo](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite obtener una salida de mayor resolución al exportar el párrafo. A continuación, se calculan los límites del párrafo teniendo en cuenta la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para usar en materiales impresos de alta calidad.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Guardar la forma en memoria como bitmap con escalado.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Crear un bitmap de la forma desde memoria.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calcular los límites del segundo párrafo.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calcular el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Preparar un bitmap para el párrafo.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redibujar el párrafo desde el bitmap de la forma al bitmap del párrafo.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Utilice el método de ajuste del marco de texto ([set_WrapText](https://reference.aspose.com/slides/es/cpp/aspose.slides/textframeformat/set_wraptext/)) para desactivar el ajuste, de modo que las líneas no se interrumpan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede recuperar el rectángulo delimitador del párrafo (e incluso de un único fragmento) para conocer su posición y tamaño exactos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraphformat/set_alignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraphformat/); se aplica a todo el párrafo sin importar el formato de los fragmentos individuales.

**¿Puedo establecer un idioma de corrección ortográfica solo para una parte del párrafo (p. ej., una palabra)?**

Sí. El idioma se establece a nivel de fragmento mediante ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_languageid/)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.