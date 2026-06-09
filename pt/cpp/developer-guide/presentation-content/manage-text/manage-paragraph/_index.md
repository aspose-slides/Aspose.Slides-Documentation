---
title: Gerenciar Parágrafos de Texto do PowerPoint em C++
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/cpp/manage-paragraph/
keywords:
- adicionar texto
- adicionar parágrafo
- gerenciar texto
- gerenciar parágrafo
- gerenciar marcador
- recuo de parágrafo
- recuo suspenso
- marcador de parágrafo
- lista numerada
- lista com marcadores
- propriedades do parágrafo
- importar HTML
- texto para HTML
- parágrafo para HTML
- parágrafo para imagem
- texto para imagem
- exportar parágrafo
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine a formatação de parágrafos com Aspose.Slides para C++ — otimize alinhamento, espaçamento e estilo em apresentações PPT, PPTX e ODP em C++."
---
## **Introdução**

Aspose.Slides fornece todas as interfaces e classes necessárias para trabalhar com textos, parágrafos e trechos do PowerPoint em C++.

* Aspose.Slides fornece a interface [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) que permite adicionar objetos que representam um parágrafo. Um objeto `ITextFame` pode ter um ou vários parágrafos (cada parágrafo é criado por meio de uma quebra de linha).
* Aspose.Slides fornece a interface [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/) que permite adicionar objetos que representam trechos. Um objeto `IParagraph` pode ter um ou vários trechos (coleção de objetos iPortions).
* Aspose.Slides fornece a interface [IPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/) que permite adicionar objetos que representam textos e suas propriedades de formatação. 

Um objeto `IParagraph` é capaz de manipular textos com diferentes propriedades de formatação através de seus objetos subjacentes `IPortion`.

## **Adicionar Vários Parágrafos contendo Vários Trechos**

Esses passos mostram como adicionar um quadro de texto contendo 3 parágrafos e cada parágrafo contendo 3 trechos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um retângulo [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
4. Obtenha o ITextFrame associado ao [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/).
5. Crie dois objetos [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/) e adicione-os à coleção `IParagraphs` do [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/).
6. Crie três objetos [IPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/) para cada novo `IParagraph` (dois objetos Portion para o Parágrafo padrão) e adicione cada objeto `IPortion` à coleção IPortion de cada `IParagraph`.
7. Defina algum texto para cada trecho.
8. Aplique os recursos de formatação desejados a cada trecho usando as propriedades de formatação expostas pelo objeto `IPortion`.
9. Salve a apresentação modificada.

Este código C++ é uma implementação dos passos para adicionar parágrafos contendo trechos: 

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Carregar a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessar o primeiro slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adicionar um AutoShape do tipo Retângulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Adicionar TextFrame ao Retângulo
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Acessando o primeiro Parágrafo
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Adicionando o segundo Parágrafo
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Adicionando o terceiro Parágrafo
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

// Salvar PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Gerenciar Marcadores de Parágrafo**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com marcadores são sempre mais fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione uma [autoshape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide selecionado.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da autoshape. 
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/).
7. Defina o `Type` do marcador para o parágrafo como `Symbol` e defina o caractere do marcador.
8. Defina o `Text` do parágrafo.
9. Defina o `Indent` do parágrafo para o marcador.
10. Defina uma cor para o marcador.
11. Defina uma altura para o marcador.
12. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
13. Adicione o segundo parágrafo e repita o processo descrito nas etapas 7 a 13.
14. Salve a apresentação.

Este código C++ mostra como adicionar um marcador de parágrafo:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Carregar a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessar o primeiro slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adicionar um AutoShape do tipo Retângulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Adicionar TextFrame ao Retângulo
ashp->AddTextFrame(u"");

// Acessando o quadro de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Criar o objeto Paragraph para o quadro de texto
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Setting Text
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Definir recuo do marcador
paragraph->get_ParagraphFormat()->set_Indent (25);

// Definir cor do marcador
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// definir IsBulletHardColor como true para usar a cor própria do marcador
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Definir altura do marcador
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Adicionar Parágrafo ao quadro de texto
txtFrame->get_Paragraphs()->Add(paragraph);

// Criando segundo parágrafo
// Criar o objeto Paragraph para o quadro de texto
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Setting Text
paragraph2->set_Text(u"This is numbered bullet");

// Definir tipo e estilo do marcador do parágrafo
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Definir recuo do marcador
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Definir cor do marcador
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// definir IsBulletHardColor como true para usar a cor própria do marcador
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Definir altura do marcador
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Adicionar Parágrafo ao quadro de texto
txtFrame->get_Paragraphs()->Add(paragraph2);


// Salvar PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Gerenciar Marcadores de Imagem**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com imagens são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione uma [autoshape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da autoshape. 
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/).
7. Carregue a imagem em [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/).
8. Defina o tipo de marcador como [Picture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) e defina a imagem.
9. Defina o `Text` do Parágrafo.
10. Defina o `Indent` do Parágrafo para o marcador.
11. Defina uma cor para o marcador.
12. Defina uma altura para o marcador.
13. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
14. Adicione o segundo parágrafo e repita o processo com base nas etapas anteriores.
15. Salve a apresentação modificada.

Este código C++ mostra como adicionar e gerenciar marcadores de imagem:

```c++
// Instancia uma classe Presentation que representa um arquivo PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Acessa o primeiro slide
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instancia a imagem para marcadores
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Adiciona e acessa o AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Acessa o TextFrame do autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Remove o parágrafo padrão
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Cria um novo parágrafo
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Define o estilo e a imagem do marcador do parágrafo
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Define a altura do marcador
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Adiciona o parágrafo ao TextFrame
paragraphs->Add(paragraph);

// Grava a apresentação como um arquivo PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Grava a apresentação como um arquivo PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Gerenciar Marcadores Multinível**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Marcadores multinível são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione uma [autoshape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) no novo slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da autoshape. 
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/) e defina a profundidade como 0.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina a profundidade como 1.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina a profundidade como 2.
9. Crie a quarta instância de parágrafo através da classe `Paragraph` e defina a profundidade como 3.
10. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
11. Salve a apresentação modificada.

Este código C++ mostra como adicionar e gerenciar marcadores multinível:

```c++
// Instancia uma classe Presentation que representa um arquivo PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Acessa o primeiro slide
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Adiciona e acessa o AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Acessa o TextFrame do autoshape criado
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Limpa o parágrafo padrão
text->get_Paragraphs()->Clear();

// Adiciona o primeiro parágrafo
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Define o nível do marcador
para1Format->set_Depth(0);

// Adiciona o segundo parágrafo
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Define o nível do marcador
para2Format->set_Depth(1);

// Adiciona o terceiro parágrafo
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Define o nível do marcador
para3Format->set_Depth(2);

// Adiciona o quarto parágrafo
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Define o nível do marcador
para4Format->set_Depth(3);

// Adiciona os parágrafos à coleção
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Grava a apresentação como um arquivo PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Gerenciar um Parágrafo com uma Lista Numerada Personalizada**

A interface [IBulletFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/) fornece a propriedade [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) e outras que permitem gerenciar parágrafos com numeração ou formatação personalizada. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse o slide que contém o parágrafo.
3. Adicione uma [autoshape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da autoshape. 
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/) e defina [NumberedBulletStartWith](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) como 2.
7. Crie a segunda instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` como 3.
8. Crie a terceira instância de parágrafo através da classe `Paragraph` e defina `NumberedBulletStartWith` como 7.
9. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
10. Salve a apresentação modificada.

Este código C++ mostra como adicionar e gerenciar parágrafos com numeração ou formatação personalizada:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Acessa o quadro de texto do autoshape criado
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Remove o parágrafo padrão existente
textFrame->get_Paragraphs()->RemoveAt(0);

// Primeira lista
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

## **Definir Recuo da Primeira Linha para um Parágrafo**

Use o método [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) para controlar o recuo da primeira linha de um parágrafo. Esse método move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginleft/) quando precisar mover o parágrafo inteiro. Use [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de `Indent` para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir um recuo de parágrafo:

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

O resultado:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Definir Recuo Suspenso para um Parágrafo**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com o método [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/). Defina o recuo com um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginleft/) define a posição esquerda do corpo do parágrafo, e [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo em `MarginLeft` e um valor negativo em `Indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos em que linhas quebradas devem alinhar-se sob o corpo do parágrafo e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [MarginLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginleft/) para cada parágrafo.
6. Defina um valor negativo de [Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

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

O resultado:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Gerenciar Propriedades de Execução de Fim de Parágrafo**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha a referência do slide que contém o parágrafo através de sua posição.
1. Adicione um [autoshape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) retangular ao slide.
1. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) com dois parágrafos ao retângulo.
1. Defina `FontHeight` e o tipo de fonte para os parágrafos.
1. Defina as propriedades de fim para os parágrafos.
1. Grave a apresentação modificada como um arquivo PPTX.

Este código C++ mostra como definir as propriedades de fim para parágrafos no PowerPoint: 

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Carregar a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessar o primeiro slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adicionar um AutoShape do tipo Retângulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Adicionar TextFrame ao Retângulo
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Adicionando o primeiro Parágrafo
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Adicionando o segundo Parágrafo
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);

// Salvar PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Importar Texto HTML em Parágrafos**

Aspose.Slides fornece suporte aprimorado para importar texto HTML em parágrafos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione uma [autoshape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
4. Adicione e acesse o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da autoshape.
5. Remova o parágrafo padrão no `ITextFrame`.
6. Leia o arquivo HTML de origem em um TextReader.
7. Crie a primeira instância de parágrafo através da classe [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/).
8. Adicione o conteúdo do arquivo HTML lido pelo TextReader à [ParagraphCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraphcollection/) do TextFrame.
9. Salve a apresentação modificada.

Este código C++ é uma implementação dos passos para importar textos HTML em parágrafos: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// O caminho para o diretório de documentos.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Carregar a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessar o primeiro slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adicionar um AutoShape do tipo Retângulo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Redefinindo a cor de preenchimento padrão
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Adicionar TextFrame ao Retângulo
ashp->AddTextFrame(u" ");

// Acessando o quadro de texto
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Obter a coleção de Parágrafos
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Limpar todos os parágrafos no TextFrame adicionado
ParaCollection->Clear();

// Carregando o arquivo HTML usando StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Adicionando texto do StreamReader HTML ao TextFrame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Criar o objeto Paragraph para o TextFrame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Criar objeto Portion para o parágrafo
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Obter o formato da porção
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Definir a fonte para a Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Definir a propriedade negrito da fonte
pf->set_FontBold(NullableBool::True);

// Definir a propriedade itálico da fonte
pf->set_FontItalic(NullableBool::True);

// Definir a propriedade sublinhado da fonte
pf->set_FontUnderline(TextUnderlineType::Single);

// Definir a altura da fonte
pf->set_FontHeight(25);

// Definir a cor da fonte
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Salvar PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Exportar Texto de Parágrafo para HTML**

Aspose.Slides fornece suporte aprimorado para exportar textos (contidos em parágrafos) para HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e carregue a apresentação desejada.
2. Acesse a referência do slide relevante por meio de seu índice.
3. Acesse a forma que contém o texto que será exportado para HTML.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da forma.
5. Crie uma instância de `StreamWriter` e adicione o novo arquivo HTML.
6. Forneça um índice inicial ao `StreamWriter` e exporte os parágrafos desejados.

Este código C++ mostra como exportar textos de parágrafos do PowerPoint para HTML: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// O caminho para o diretório de documentos.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Carregar a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Acessar o primeiro slide padrão da apresentação
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Índice desejado
int index = 0;

// Acessando a forma adicionada
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extraindo o primeiro parágrafo como HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Escrevendo dados dos parágrafos em HTML fornecendo o índice inicial do parágrafo e o total de parágrafos a serem copiados
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Salvar um Parágrafo como Imagem**

Nesta seção, exploraremos dois exemplos que demonstram como salvar um parágrafo de texto, representado pela interface [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/), como uma imagem. Ambos os exemplos incluem a obtenção da imagem de uma forma que contém o parágrafo usando os métodos `GetImage` da interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/), o cálculo dos limites do parágrafo dentro da forma e a exportação como imagem bitmap. Essas abordagens permitem extrair partes específicas do texto de apresentações PowerPoint e salvá‑las como imagens separadas, o que pode ser útil em diversos cenários.

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Exemplo 1**

Neste exemplo, obtemos o segundo parágrafo como imagem. Para isso, extraímos a imagem da forma do primeiro slide da apresentação e então calculamos os limites do segundo parágrafo no quadro de texto da forma. O parágrafo é então redesenhado em uma nova imagem bitmap, que é salva no formato PNG. Esse método é especialmente útil quando você precisa salvar um parágrafo específico como imagem separada, preservando as dimensões exatas e a formatação do texto.

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

O resultado:

![The paragraph image](paragraph_to_image_output.png)

**Exemplo 2**

Neste exemplo, ampliamos a abordagem anterior adicionando fatores de escala à imagem do parágrafo. A forma é extraída da apresentação e salva como imagem com um fator de escala de `2`. Isso permite uma saída de resolução mais alta ao exportar o parágrafo. Os limites do parágrafo são então calculados considerando a escala. A escala pode ser particularmente útil quando é necessária uma imagem mais detalhada, por exemplo, para uso em materiais impressos de alta qualidade.

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

## **Perguntas Frequentes**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Use o método de quebra de texto do quadro de texto ([set_WrapText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textframeformat/set_wraptext/)) para desligar a quebra, de modo que as linhas não se interrompam nas bordas do quadro.

**Como posso obter os limites exatos na lâmina de um parágrafo específico?**

Você pode recuperar o retângulo delimitador do parágrafo (e até mesmo de um único trecho) para conhecer sua posição e tamanho precisos na lâmina.

**Onde a alinhamento de parágrafo (esquerda/direita/centralizado/justificado) é controlado?**

[Alignment](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraphformat/set_alignment/) é uma configuração ao nível do parágrafo em [ParagraphFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraphformat/); ela se aplica a todo o parágrafo, independentemente da formatação individual dos trechos.

**Posso definir um idioma de verificação ortográfica para apenas parte de um parágrafo (por exemplo, uma palavra)?**

Sim. O idioma é definido ao nível do trecho usando ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_languageid/)), permitindo que múltiplos idiomas coexistam dentro de um único parágrafo.