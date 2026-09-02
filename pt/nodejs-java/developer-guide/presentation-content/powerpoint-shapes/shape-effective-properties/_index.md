---
title: Obter Propriedades Efetivas de Formas de Apresentações em JavaScript
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/nodejs-java/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de iluminação
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Saiba como usar Aspose.Slides para Node.js via Java para distinguir a formatação local, herdada e efetiva de formas em apresentações PowerPoint."
---
## **Entender Propriedades Locais, Herdadas e Efetivas**

A formatação do PowerPoint pode vir de vários lugares. O valor armazenado diretamente em um objeto é seu **valor local**. Se esse valor não estiver definido, o PowerPoint procura fontes de formatação pai, como o padrão de parágrafo, um estilo de texto, um layout ou slide mestre, um tema ou padrões a nível de apresentação. Esses valores são **valores herdados**. O valor que resta depois que toda a hierarquia é resolvida é o **valor efetivo** — o valor usado para renderizar o objeto.

Por exemplo, uma porção de texto pode não definir sua própria altura de fonte. Seu valor local [getFontHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getFontHeight) passa a ser `NaN`, que significa "não definido aqui". A porção pode herdar uma altura do seu parágrafo, do estilo de texto padrão da apresentação ou de outra fonte aplicável. Chamar [getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getEffective) no formato da porção retorna a altura final resolvida.

Use os dois tipos de dados de formatação para propósitos diferentes:

- Leia ou altere um objeto de formato local, como [PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/), quando precisar controlar onde um valor é definido.
- Leia os [dados efetivos retornados por PortionFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getEffective) quando precisar do resultado final renderizado. Dados efetivos são somente leitura.

Antes de executar os exemplos, [install Aspose.Slides for Node.js via Java](/slides/pt/nodejs-java/installation/).

## **Comparar Valores Locais, Herdados e Efetivos**

O exemplo completo a seguir cria uma forma e aplica alturas de fonte nos níveis de apresentação, parágrafo e porção. Cada etapa imprime os valores definidos nesses níveis e o valor efetivo resultante para a mesma porção de texto. Ele também demonstra por que os dados efetivos devem ser lidos novamente após alterações de formatação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Ler dados efetivos após as alterações anteriores.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Definir valores herdados em dois níveis diferentes.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Um valor local na porção substitui ambos os valores herdados.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Alterar um valor herdado não substitui um valor local existente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Limpar o valor local. A porção agora herda novamente do parágrafo.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Limpar o valor do parágrafo. O padrão da apresentação agora fornece o resultado.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A prioridade neste exemplo é a formatação local da porção, seguida pela formatação do parágrafo e, por fim, o padrão da apresentação. Outros objetos podem ter cadeias de herança diferentes, mas o princípio é o mesmo: um valor explícito mais específico vence, e [getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getEffective) retorna o resultado final.

## **Obter Propriedades de Texto Efetivas**

A formatação de texto está dividida entre vários objetos:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/#getEffective) resolve propriedades de quadro de texto como margens, ancoragem, ajuste automático e direção vertical do texto.
- [TextStyle.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textstyle/#getEffective) resolve a formatação de parágrafo para cada nível de estilo de texto.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraphformat/#getEffective) resolve propriedades de parágrafo como alinhamento, recuo e marcadores.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/#getEffective) resolve propriedades de caracteres como altura da fonte, tipo de letra, cor, negrito e itálico.

Para o próximo exemplo, `text-formatting.pptx` deve conter ao menos um slide e uma [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) com um quadro de texto não vazio. A AutoShape pode aparecer em qualquer posição na coleção de formas; o código procura um objeto adequado e o valida antes de usar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Obter Propriedades 3D Efetivas**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getEffective) retorna um único objeto de dados efetivo que agrupa todas as configurações 3D resolvidas. Seus métodos [getCamera](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/#getBevelBottom) expõem os respectivos dados efetivos. Ler essas configurações relacionadas juntas facilita a compreensão da aparência 3D final de uma forma.

Para este exemplo, `shape-3d.pptx` deve conter ao menos uma forma no primeiro slide. Aplique configurações de câmera 3D, iluminação ou chanfradura nessa forma se quiser que a saída contenha valores diferentes dos padrões.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Obter Formatação de Tabela Efetiva**

A formatação de tabela pode vir do estilo da tabela e de formatos aplicados à tabela inteira, a uma coluna, a uma linha ou a uma célula individual. Em conflitos entre preenchimentos definidos explicitamente, a prioridade é célula, linha, coluna e, por fim, tabela inteira. O formato efetivo de uma célula é o formato final usado para desenhá‑la.

Para este exemplo, `table-formatting.pptx` deve conter ao menos uma tabela no primeiro slide. A tabela deve ter ao menos uma linha e uma coluna. O código procura por uma [Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/table/) em vez de assumir que `getShapes().get_Item(0)` é uma tabela.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Se precisar da cor ao invés apenas do tipo de preenchimento, primeiro verifique o [getFillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/#getFillType) efetivo e, em seguida, leia o método que se aplica a esse tipo — por exemplo, [getSolidFillColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) para um preenchimento sólido.

## **Reler Dados Efetivos Após Alterações**

Dados efetivos descrevem a hierarquia de formatação no momento em que são resolvidos. Chame `getEffective` novamente após alterar qualquer coisa que possa participar dessa hierarquia, incluindo:

- a formatação local do objeto;
- padrões de parágrafo ou de quadro de texto;
- um estilo de tabela, tabela, coluna, linha ou formato de célula;
- formatação de layout ou slide mestre;
- dados de tema ou padrões a nível de apresentação;
- o layout ou mestre atribuído a um slide.

Não mantenha um objeto de dados efetivo como um instantâneo permanente. Aspose.Slides pode armazenar em cache alguns dados efetivos internamente, e uma chamada posterior a `getEffective` pode atualizar esses dados. Se precisar comparar valores antes e depois de uma mudança, copie os valores escalares que precisar — como altura da fonte, cor, alinhamento ou largura da chanfradura — para suas próprias variáveis antes de fazer a alteração.

Para alterar um valor, atualize o objeto de formato local apropriado e então chame `getEffective` para verificar o resultado. Os próprios objetos de dados efetivos são somente leitura.

## **Perguntas Frequentes**

**Como posso saber qual nível forneceu um valor efetivo?**

Os dados efetivos contêm o valor final, não sua origem. Inspecione os objetos locais aplicáveis do nível mais específico para fora. Para texto, isso pode incluir a porção, o parágrafo, o quadro de texto, o layout, o mestre, o tema e os padrões da apresentação. Valores indefinidos como `NaN` ou `null` indicam que a busca continua para outro nível.

**O que acontece quando nenhum nível define uma propriedade?**

Aspose.Slides resolve o padrão apropriado do PowerPoint ou da biblioteca. Esse valor resolvido aparece nos dados efetivos mesmo que nenhum objeto local o defina explicitamente.

**Por que um valor efetivo às vezes é igual ao valor local?**

O valor local venceu o cálculo de herança. Isso é esperado quando a propriedade está explicitamente definida no objeto e nenhuma regra mais específica a sobrescreve.

**Quando devo usar dados locais em vez de dados efetivos?**

Use dados locais para inspecionar ou editar um nível específico de formatação. Use dados efetivos quando precisar da aparência final após herança, regras de tema e estilos aplicáveis terem sido resolvidos. O [complete comparison example](#compare-local-inherited-and-effective-values) demonstra ambos no mesmo fluxo de trabalho.