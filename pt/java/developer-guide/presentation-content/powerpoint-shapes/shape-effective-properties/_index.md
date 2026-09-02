---
title: Obter Propriedades Efetivas de Forma de Apresentações em Java
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/java/shape-effective-properties/
keywords:
  - propriedades de forma
  - propriedades de câmera
  - configuração de iluminação
  - forma chanfrada
  - quadro de texto
  - estilo de texto
  - altura da fonte
  - formato de preenchimento
  - PowerPoint
  - apresentação
  - Java
  - Aspose.Slides
description: "Aprenda a usar o Aspose.Slides para Java para distinguir a formatação local, herdada e efetiva de formas em apresentações do PowerPoint."
---
## **Entender Propriedades Locais, Herdadas e Efetivas**

A formatação do PowerPoint pode vir de vários locais. O valor armazenado diretamente em um objeto é seu **valor local**. Se esse valor não estiver definido, o PowerPoint busca nas fontes de formatação pai, como o padrão de parágrafo, um estilo de texto, um layout ou slide mestre, um tema ou valores padrão do nível de apresentação. Esses valores são **valores herdados**. O valor que resta após que toda a hierarquia é resolvida é o **valor efetivo** — o valor usado para renderizar o objeto.

Por exemplo, uma parte de texto pode não definir sua própria altura de fonte. Seu valor local [getFontHeight](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) então é `Float.NaN`, que significa "não definido aqui". A parte pode herdar uma altura de seu parágrafo, do estilo de texto padrão da apresentação ou de outra fonte aplicável. Chamar [getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportionformat/#getEffective--) no formato da parte retorna a altura final resolvida.

Use os dois tipos de dados de formatação para diferentes propósitos:

- Leia ou altere um objeto de formato local, como [IPortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportionformat/), quando precisar controlar onde um valor é definido.
- Leia um objeto de dados efetivo, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportionformateffectivedata/), quando precisar do resultado final renderizado. Dados efetivos são somente leitura.

## **Comparar Valores Locais, Herdados e Efetivos**

O exemplo completo a seguir cria uma forma e aplica alturas de fonte nos níveis de apresentação, parágrafo e parte. Cada passo imprime os valores definidos nesses níveis e o valor efetivo resultante para a mesma parte de texto. Ele também demonstra por que os dados efetivos precisam ser lidos novamente após alterações de formatação.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Defina valores herdados em dois níveis diferentes.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Um valor local na parte substitui ambos os valores herdados.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Alterar um valor herdado não substitui um valor local existente.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Limpe o valor local. A parte agora herda novamente do parágrafo.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Limpe o valor do parágrafo. O padrão da apresentação agora fornece o resultado.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Leia os dados efetivos após as alterações anteriores.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

A prioridade neste exemplo é a formatação local da parte, depois a formatação do parágrafo e, por fim, o padrão da apresentação. Outros objetos podem ter cadeias de herança diferentes, mas o princípio é o mesmo: um valor explícito mais específico prevalece, e [getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportionformat/#getEffective--) retorna o resultado final.

## **Obter Propriedades de Texto Efetivas**

A formatação de texto é dividida entre vários objetos:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframeformat/#getEffective--) resolve as propriedades de quadro de texto, como margens, ancoragem, ajuste automático e direção vertical do texto.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextstyle/#getEffective--) resolve a formatação de parágrafo para cada nível de estilo de texto.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraphformat/#getEffective--) resolve as propriedades de parágrafo, como alinhamento, recuo e marcadores.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportionformat/#getEffective--) resolve as propriedades de caractere, como altura de fonte, tipo de fonte, cor, negrito e itálico.

Para o próximo exemplo, `text-formatting.pptx` deve conter ao menos um slide e um [AutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/autoshape/) com um quadro de texto não vazio. O AutoShape pode aparecer em qualquer posição na coleção de formas; o código procura um objeto adequado e o valida antes do uso.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Obter Propriedades 3D Efetivas**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ithreedformat/#getEffective--) retorna um objeto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ithreedformateffectivedata/) que agrupa todas as configurações 3D resolvidas. Seus métodos [getCamera](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), e [getBevelBottom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) expõem os dados efetivos correspondentes. Ler essas configurações relacionadas juntas facilita a compreensão da aparência 3D final de uma forma.

Para este exemplo, `shape-3d.pptx` deve conter ao menos uma forma no primeiro slide. Aplique configurações de câmera 3D, iluminação ou chanfradura a essa forma se quiser que a saída contenha valores diferentes dos padrão.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Obter Formatação de Tabela Efetiva**

A formatação de tabela pode vir do estilo de tabela e de formatos aplicados à tabela inteira, a uma coluna, a uma linha ou a uma célula individual. Em conflitos entre preenchimentos definidos explicitamente, a prioridade é célula, linha, coluna e, depois, a tabela inteira. O formato efetivo de uma célula é o formato final usado para desenhá‑la.

Para este exemplo, `table-formatting.pptx` deve conter ao menos uma tabela no primeiro slide. A tabela deve ter ao menos uma linha e uma coluna. O código procura um [ITable](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itable/) em vez de supor que `getShapes().get_Item(0)` seja uma tabela.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Se precisar da cor em vez de apenas o tipo de preenchimento, primeiro verifique o [getFillType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) efetivo e, em seguida, leia o método que se aplica a esse tipo — por exemplo, [getSolidFillColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) para um preenchimento sólido.

## **Ler Dados Efetivos Novamente Após Alterações**

Os dados efetivos descrevem a hierarquia de formatação no momento em que são resolvidos. Chame `getEffective` novamente após alterar qualquer coisa que possa participar dessa hierarquia, incluindo:

- a formatação local do objeto;
- os padrões de parágrafo ou quadro de texto;
- um estilo de tabela, tabela, coluna, linha ou formato de célula;
- a formatação de layout ou slide mestre;
- os dados do tema ou padrões ao nível da apresentação;
- o layout ou mestre atribuído a um slide.

Não mantenha um objeto de dados efetivo como um instantâneo permanente. O Aspose.Slides pode armazenar em cache alguns dados efetivos internamente, e uma chamada posterior a `getEffective` pode atualizar esses dados. Se precisar comparar valores antes e depois de uma alteração, copie os valores escalares necessários — como altura de fonte, cor, alinhamento ou largura da chanfradura — para suas próprias variáveis antes de fazer a alteração.

Para alterar um valor, atualize o objeto de formato local apropriado e então chame `getEffective` para verificar o resultado. Os próprios objetos de dados efetivos são somente leitura.

## **Perguntas Frequentes**

**Como posso saber qual nível forneceu um valor efetivo?**

Os dados efetivos contêm o valor final, não sua origem. Inspecione os objetos locais aplicáveis a partir do nível mais específico para fora. Para texto, isso pode incluir a parte, parágrafo, quadro de texto, layout, mestre, tema e padrões da apresentação. Valores indefinidos como `Float.NaN` ou `null` indicam que a busca continua em outro nível.

**O que acontece quando nenhum nível define uma propriedade?**

O Aspose.Slides resolve o padrão adequado do PowerPoint ou da biblioteca. Esse valor resolvido aparece nos dados efetivos embora nenhum objeto local o defina explicitamente.

**Por que um valor efetivo às vezes é igual ao valor local?**

O valor local venceu o cálculo de herança. Isso é esperado quando a propriedade está explicitamente definida no objeto e nenhuma regra mais específica a substitui.

**Quando devo usar dados locais em vez de dados efetivos?**

Use dados locais para inspecionar ou editar um nível específico de formatação. Use dados efetivos quando precisar da aparência final após herança, regras de tema e estilos aplicáveis terem sido resolvidos. O [exemplo completo de comparação](#compare-local-inherited-and-effective-values) demonstra ambos no mesmo fluxo de trabalho.