---
title: Gerenciar formas de apresentação em C++
linktitle: Manipulação de formas
type: docs
weight: 40
url: /pt/cpp/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID de forma Interop
- Texto alternativo da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar, editar e otimizar formas no Aspose.Slides para C++ e entregar apresentações PowerPoint de alto desempenho."
---
## **Visão geral**

Este artigo explica como trabalhar com formas em apresentações usando Aspose.Slides. Ele mostra como encontrar uma forma em um slide, cloná‑la, removê‑la, ocultá‑la, alterar sua ordem, obter seu ID de forma Interop e definir texto alternativo para identificação e processamento posterior.

Também aborda como acessar formatos de layout para formas, renderizar uma forma como SVG, alinhar formas em um slide e usar propriedades de flip para espelhamento horizontal e vertical. Além disso, o artigo inclui um breve FAQ sobre combinação de formas, ordem de empilhamento e bloqueio de formas.

## **Encontrar uma forma em um slide**
Este tópico descreve uma técnica simples para facilitar aos desenvolvedores a localização de uma forma específica em um slide sem usar seu Id interno. É importante saber que os arquivos de apresentação do PowerPoint não possuem nenhuma maneira de identificar formas em um slide, exceto por um Id interno exclusivo. Parece ser difícil para os desenvolvedores encontrar uma forma usando seu Id interno exclusivo. Todas as formas adicionadas aos slides possuem algum Texto Alternativo. Sugerimos que os desenvolvedores usem texto alternativo para encontrar uma forma específica. Você pode usar o MS PowerPoint para definir o texto alternativo para objetos que planeja alterar no futuro.

Depois de definir o texto alternativo de qualquer forma desejada, você pode abrir a apresentação usando Aspose.Slides for C++ e iterar por todas as formas adicionadas a um slide. Durante cada iteração, você pode verificar o texto alternativo da forma e a forma com o texto alternativo correspondente será a forma requerida. Para demonstrar essa técnica de forma mais clara, criamos o método [FindShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) que realiza a busca de uma forma específica em um slide e simplesmente retorna essa forma.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Clonar uma forma**
Para clonar uma forma em um slide usando Aspose.Slides for C++:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Obtenha a referência de um slide usando seu índice.
3. Acesse a coleção de formas do slide de origem.
4. Adicione um novo slide à apresentação.
5. Clone as formas da coleção de formas do slide de origem para o novo slide.
6. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Remover uma forma**
Aspose.Slides for C++ permite que os desenvolvedores removam qualquer forma. Para remover a forma de qualquer slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Acesse o primeiro slide.
3. Encontre a forma com um TextoAlternativo específico.
4. Remova a forma.
5. Salve o arquivo no disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Ocultar uma forma**
Aspose.Slides for C++ permite que os desenvolvedores ocultem qualquer forma. Para ocultar a forma de qualquer slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Acesse o primeiro slide.
3. Encontre a forma com um TextoAlternativo específico.
4. Oculte a forma.
5. Salve o arquivo no disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Alterar a ordem da forma**
Aspose.Slides for C++ permite que os desenvolvedores reordenem as formas. Reordenar a forma especifica qual forma está na frente ou qual está atrás. Para reordenar a forma de qualquer slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Acesse o primeiro slide.
3. Adicione uma forma.
4. Adicione texto ao quadro de texto da forma.
5. Adicione outra forma com as mesmas coordenadas.
6. Reordene as formas.
7. Salve o arquivo no disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Obter o ID de forma Interop**
Aspose.Slides for C++ permite que os desenvolvedores obtenham um identificador de forma exclusivo no escopo do slide, em contraste com a propriedade UniqueId, que permite obter um identificador exclusivo no escopo da apresentação. A propriedade OfficeInteropShapeId foi adicionada às interfaces IShape e à classe Shape, respectivamente. O valor retornado pela propriedade OfficeInteropShapeId corresponde ao valor do Id do objeto Microsoft.Office.Interop.PowerPoint.Shape. Abaixo está o código de exemplo fornecido.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Definir a propriedade AlternativeText**
Aspose.Slides for C++ permite que os desenvolvedores definam o AlternativeText de qualquer forma. Para definir o AlternativeText de uma forma, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Acesse o primeiro slide.
3. Adicione qualquer forma ao slide.
4. Execute algumas operações com a forma recém‑adicionada.
5. Percorra as formas para encontrar uma forma.
6. Defina o AlternativeText.
7. Salve o arquivo no disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Acessar formatos de layout para uma forma**
Aspose.Slides for C++ permite que os desenvolvedores acessem formatos de layout para uma forma. Este artigo demonstra como acessar as propriedades **FillFormat** e **LineFormat** de uma forma.

Abaixo está o código de exemplo fornecido.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Renderizar uma forma como SVG**
Agora o Aspose.Slides for C++ oferece suporte à renderização de uma forma como SVG. O método WriteAsSvg (e sua sobrecarga) foi adicionado à classe Shape e à interface IShape. Este método permite salvar o conteúdo da forma como um arquivo SVG. O trecho de código abaixo mostra como exportar a forma de um slide para um arquivo SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Alinhamento de formas**
Aspose.Slides permite alinhar formas relativas às margens do slide ou relativas entre si. Para esse fim, foi adicionada uma sobrecarga do método [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). A enumeração [ShapesAlignmentType](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) define as opções de alinhamento possíveis.

**Exemplo 1**

O código-fonte abaixo alinha as formas com índices 1, 2 e 4 ao longo da borda superior do slide.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Exemplo 2**

O exemplo abaixo mostra como alinhar toda a coleção de formas em relação à forma mais inferior da coleção.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Propriedades de Flip**

No Aspose.Slides, a classe [ShapeFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapeframe/) fornece controle sobre o espelhamento horizontal e vertical de formas por meio das propriedades `flipH` e `flipV`. Ambas as propriedades são do tipo [NullableBool](https://reference.aspose.com/slides/pt/cpp/aspose.slides/nullablebool/), permitindo valores `True` para indicar um flip, `False` para nenhum flip ou `NotDefined` para usar o comportamento padrão. Esses valores são acessíveis a partir do [Frame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_frame/) de uma forma.

Para modificar as configurações de flip, uma nova instância de [ShapeFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapeframe/) é construída com a posição e tamanho atuais da forma, os valores desejados para `flipH` e `flipV` e o ângulo de rotação. Atribuir essa instância ao [Frame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_frame/) da forma e salvar a apresentação aplica as transformações de espelhamento e as grava no arquivo de saída.

Vamos supor que temos um arquivo sample.pptx no qual o primeiro slide contém uma única forma com configurações de flip padrão, conforme mostrado abaixo.

![A forma a ser invertida](shape_to_be_flipped.png)

O exemplo de código a seguir recupera as propriedades de flip atuais da forma e a inverte tanto horizontalmente quanto verticalmente.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Recuperar a propriedade de espelhamento horizontal da forma.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Recuperar a propriedade de espelhamento vertical da forma.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Inverter horizontalmente.
auto flipV = NullableBool::True; // Inverter horizontalmente.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![A forma invertida](flipped_shape.png)

## **FAQ**

**Posso combinar formas (união/interseção/subtração) em um slide como em um editor de desktop?**

Não existe uma API de operação booleana embutida. Você pode aproximar isso construindo manualmente o contorno desejado — por exemplo, calcular a geometria resultante (via [GeometryPath](https://reference.aspose.com/slides/pt/cpp/aspose.slides/geometrypath/)) e criar uma nova forma com esse contorno, removendo opcionalmente as originais.

**Como posso controlar a ordem de empilhamento (z‑order) para que uma forma fique sempre “no topo”?**

Altere a ordem de inserção/movimento dentro da coleção de [shapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseslide/get_shapes/) do slide. Para resultados previsíveis, finalize o z‑order após todas as outras modificações do slide.

**Posso "bloquear" uma forma para impedir que usuários a editem no PowerPoint?**

Sim. Defina as [flags de proteção ao nível da forma](/slides/pt/cpp/applying-protection-to-presentation/) (por exemplo, bloquear seleção, movimento, redimensionamento, edições de texto). Se necessário, reflita as restrições no mestre ou layout. Observe que isso é proteção ao nível da UI, não um recurso de segurança; para proteção mais forte, combine com restrições ao nível de arquivo, como recomendações de somente‑leitura ou senhas [/slides/pt/cpp/password-protected-presentation/].