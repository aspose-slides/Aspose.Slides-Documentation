---
title: "Lấy Thuộc tính Hiệu quả của Shape từ Bản trình chiếu trên Android"
linktitle: "Thuộc tính Hiệu quả"
type: docs
weight: 50
url: /vi/androidjava/shape-effective-properties/
keywords:
- "thuộc tính hình"
- "thuộc tính máy ảnh"
- "bố trí ánh sáng"
- "hình bevel"
- "khung văn bản"
- "kiểu văn bản"
- "chiều cao phông chữ"
- "định dạng tô đầy"
- "PowerPoint"
- "bản trình chiếu"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Tìm hiểu cách sử dụng Aspose.Slides cho Android qua Java để phân biệt định dạng shape cục bộ, kế thừa và thực tế trong các bản trình chiếu PowerPoint."
---
## **Hiểu Thuộc tính Cục bộ, Kế thừa và Thực tế**

Định dạng PowerPoint có thể xuất phát từ nhiều nguồn. Giá trị được lưu trực tiếp trên một đối tượng là **giá trị cục bộ**. Nếu giá trị đó không được đặt, PowerPoint sẽ xem các nguồn định dạng cha, chẳng hạn như mặc định đoạn, kiểu văn bản, bố cục hoặc slide master, chủ đề, hoặc mặc định ở mức bản trình chiếu. Những giá trị đó là **giá trị kế thừa**. Giá trị còn lại sau khi toàn bộ cấp bậc được giải quyết là **giá trị thực tế** — giá trị được dùng để hiển thị đối tượng.

Ví dụ, một đoạn văn bản có thể không xác định chiều cao phông chữ riêng. Giá trị cục bộ [getFontHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) của nó sẽ là `Float.NaN`, có nghĩa là "không được đặt ở đây." Đoạn có thể kế thừa chiều cao từ đoạn (paragraph), kiểu văn bản mặc định của bản trình chiếu, hoặc nguồn áp dụng khác. Gọi [getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformat/#getEffective--) trên định dạng đoạn sẽ trả về chiều cao đã được giải quyết cuối cùng.

Sử dụng hai loại dữ liệu định dạng cho các mục đích khác nhau:

- Đọc hoặc thay đổi đối tượng định dạng cục bộ, chẳng hạn như [IPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformat/), khi bạn cần kiểm soát nơi một giá trị được định nghĩa.
- Đọc một đối tượng dữ liệu thực tế, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformateffectivedata/), khi bạn cần kết quả cuối cùng, đã được render. Dữ liệu thực tế chỉ đọc.

## **So sánh Giá trị Cục bộ, Kế thừa và Thực tế**

Ví dụ hoàn chỉnh dưới đây tạo một shape và áp dụng chiều cao phông chữ ở mức bản trình chiếu, đoạn và phần. Mỗi bước in ra các giá trị được định nghĩa ở các mức đó và giá trị thực tế kết quả cho cùng một phần văn bản. Nó cũng minh họa tại sao dữ liệu thực tế phải được đọc lại sau khi thay đổi định dạng.

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

            // Xác định các giá trị kế thừa ở hai mức độ khác nhau.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Giá trị cục bộ trên phần ghi đè cả hai giá trị kế thừa.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Thay đổi một giá trị kế thừa sẽ không ghi đè giá trị cục bộ hiện có.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Xóa giá trị cục bộ. Phần sẽ kế thừa lại từ đoạn.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Xóa giá trị đoạn. Mặc định bản trình chiếu bây giờ cung cấp kết quả.
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

        // Đọc dữ liệu thực tế sau các thay đổi trước đó.
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

Ưu tiên trong ví dụ này là định dạng cục bộ của phần, sau đó là định dạng đoạn, cuối cùng là mặc định bản trình chiếu. Các đối tượng khác có thể có chuỗi kế thừa khác, nhưng nguyên tắc vẫn giống: một giá trị cụ thể, rõ ràng sẽ thắng, và [getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformat/#getEffective--) trả về kết quả cuối cùng.

## **Nhận Thuộc tính Văn bản Thực tế**

Định dạng văn bản được chia ra qua nhiều đối tượng:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getEffective--) giải quyết các thuộc tính khung văn bản như lề, neo, tự động vừa, và hướng văn bản dọc.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextstyle/#getEffective--) giải quyết định dạng đoạn cho mỗi cấp độ kiểu văn bản.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) giải quyết các thuộc tính đoạn như căn chỉnh, thụt lề và dấu đầu dòng.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformat/#getEffective--) giải quyết các thuộc tính ký tự như chiều cao phông, họ phông, màu, đậm và nghiêng.

Đối với ví dụ tiếp theo, `text-formatting.pptx` phải chứa ít nhất một slide và một [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/) có khung văn bản không rỗng. AutoShape có thể xuất hiện ở bất kỳ vị trí nào trong bộ sưu tập shape; mã sẽ tìm kiếm một đối tượng phù hợp và xác thực trước khi sử dụng.

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

## **Nhận Thuộc tính 3D Thực tế**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getEffective--) trả về một đối tượng [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/) nhóm tất cả các thiết lập 3D đã được giải quyết. Các phương thức [getCamera](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), và [getBevelBottom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) bật ra dữ liệu thực tế tương ứng. Đọc các thiết lập liên quan này cùng nhau giúp dễ dàng hiểu được diện mạo 3D cuối cùng của một shape.

Đối với ví dụ này, `shape-3d.pptx` phải chứa ít nhất một shape trên slide đầu tiên. Áp dụng cài đặt máy ảnh 3D, ánh sáng hoặc bevel cho shape đó nếu bạn muốn kết quả chứa các giá trị khác với mặc định.

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

## **Nhận Định dạng Bảng Thực tế**

Định dạng bảng có thể đến từ kiểu bảng và từ các định dạng áp dụng cho toàn bộ bảng, một cột, một hàng hoặc một ô riêng lẻ. Khi có xung đột giữa các fill được xác định rõ, ưu tiên là ô, hàng, cột, rồi toàn bảng. Định dạng thực tế của một ô là định dạng cuối cùng được dùng để vẽ ô đó.

Đối với ví dụ này, `table-formatting.pptx` phải chứa ít nhất một bảng trên slide đầu tiên. Bảng phải có ít nhất một hàng và một cột. Mã sẽ tìm kiếm một [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itable/) thay vì giả định `getShapes().get_Item(0)` là một bảng.

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

Nếu bạn cần màu thay vì chỉ loại fill, trước tiên kiểm tra [getFillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) trong dữ liệu thực tế, rồi đọc phương thức áp dụng cho loại đó — ví dụ, [getSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) cho fill đặc.

## **Đọc lại Dữ liệu Thực tế Sau Khi Thay đổi**

Dữ liệu thực tế mô tả cấu trúc định dạng tại thời điểm nó được giải quyết. Gọi lại `getEffective` sau khi thay đổi bất kỳ thành phần nào có thể tham gia vào cấu trúc đó, bao gồm:

- định dạng cục bộ của đối tượng;
- mặc định đoạn hoặc khung văn bản;
- kiểu bảng, bảng, cột, hàng hoặc định dạng ô;
- định dạng bố cục hoặc slide master;
- dữ liệu chủ đề hoặc mặc định ở mức bản trình chiếu;
- bố cục hoặc master được gán cho slide.

Không lưu một đối tượng dữ liệu thực tế làm ảnh chụp nhanh vĩnh viễn. Aspose.Slides có thể cache một số dữ liệu thực tế nội bộ, và một lần gọi `getEffective` sau đó có thể làm mới dữ liệu. Nếu bạn cần so sánh giá trị trước và sau khi thay đổi, sao chép các giá trị vô hướng bạn cần — chẳng hạn như chiều cao phông, màu, căn chỉnh hoặc độ rộng bevel — vào các biến riêng của bạn trước khi thực hiện thay đổi.

Để thay đổi một giá trị, cập nhật đối tượng định dạng cục bộ tương ứng rồi gọi `getEffective` để xác minh kết quả. Các đối tượng dữ liệu thực tế tự chúng chỉ được đọc.

## **FAQ**

**Làm sao tôi biết mức nào đã cung cấp giá trị thực tế?**

Dữ liệu thực tế chỉ chứa giá trị cuối cùng, không phải nguồn gốc. Kiểm tra các đối tượng cục bộ áp dụng từ mức cụ thể nhất ra ngoài. Đối với văn bản, điều này có thể bao gồm phần, đoạn, khung văn bản, bố cục, master, chủ đề và mặc định bản trình chiếu. Các giá trị chưa xác định như `Float.NaN` hoặc `null` cho biết việc tìm kiếm sẽ tiếp tục sang mức khác.

**Điều gì xảy ra khi không có mức nào định nghĩa thuộc tính?**

Aspose.Slides sẽ giải quyết giá trị mặc định phù hợp của PowerPoint hoặc thư viện. Giá trị đã giải quyết đó sẽ xuất hiện trong dữ liệu thực tế mặc dù không có đối tượng cục bộ nào xác định rõ nó.

**Tại sao đôi khi giá trị thực tế lại bằng giá trị cục bộ?**

Giá trị cục bộ đã thắng trong phép tính kế thừa. Điều này xảy ra khi thuộc tính được đặt rõ ràng trên đối tượng và không có quy tắc cụ thể hơn nào ghi đè lên nó.

**Khi nào tôi nên dùng dữ liệu cục bộ thay vì dữ liệu thực tế?**

Dùng dữ liệu cục bộ để kiểm tra hoặc chỉnh sửa mức định dạng cụ thể. Dùng dữ liệu thực tế khi bạn cần kết quả hiển thị cuối cùng sau khi đã giải quyết kế thừa, quy tắc chủ đề và các kiểu áp dụng. Ví dụ **so sánh đầy đủ** (#compare-local-inherited-and-effective-values) minh họa cả hai trong cùng một quy trình.