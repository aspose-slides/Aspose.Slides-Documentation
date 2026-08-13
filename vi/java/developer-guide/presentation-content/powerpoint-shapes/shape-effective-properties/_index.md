---
title: "Lấy Các Thuộc Tính Hiệu Lực của Shape từ Bản Trình Chiếu trong Java"
linktitle: "Thuộc Tính Hiệu Lực"
type: docs
weight: 50
url: /vi/java/shape-effective-properties/
keywords:
- "thuộc tính hình dạng"
- "thuộc tính camera"
- "bộ ánh sáng"
- "hình bevel"
- "khung văn bản"
- "kiểu văn bản"
- "chiều cao phông chữ"
- "định dạng nền"
- "PowerPoint"
- "bản trình chiếu"
- "Java"
- "Aspose.Slides"
description: "Tìm hiểu cách sử dụng Aspose.Slides cho Java để phân biệt định dạng shape cục bộ, kế thừa và hiệu lực trong các bản trình chiếu PowerPoint."
---
## **Hiểu Các Thuộc Tính Cục Bộ, Kế Thừa và Hiệu Lực**

Định dạng PowerPoint có thể đến từ nhiều nguồn. Giá trị được lưu trữ trực tiếp trên một đối tượng là **giá trị cục bộ** của nó. Nếu giá trị này không được đặt, PowerPoint sẽ xem các nguồn định dạng cha, chẳng hạn như mặc định đoạn văn, kiểu văn bản, bố cục hoặc slide master, chủ đề, hoặc các mặc định ở mức trình chiếu. Các giá trị đó là **giá trị kế thừa**. Giá trị còn lại sau khi toàn bộ chuỗi kế thừa được giải quyết là **giá trị hiệu lực**—giá trị được dùng để hiển thị đối tượng.

Ví dụ, một phần văn bản có thể không xác định chiều cao phông chữ của riêng mình. Giá trị cục bộ của nó là [getFontHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) sẽ là `Float.NaN`, nghĩa là “không được đặt ở đây”. Phần này có thể kế thừa chiều cao từ đoạn văn, kiểu văn bản mặc định của bài thuyết trình, hoặc một nguồn áp dụng khác. Gọi [getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/#getEffective--) trên định dạng phần sẽ trả về chiều cao đã được giải quyết cuối cùng.

Sử dụng hai loại dữ liệu định dạng cho các mục đích khác nhau:

- Đọc hoặc thay đổi một đối tượng định dạng cục bộ, chẳng hạn như [IPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/), khi bạn cần kiểm soát nơi một giá trị được định nghĩa.
- Đọc một đối tượng dữ liệu hiệu lực, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformateffectivedata/), khi bạn cần kết quả cuối cùng đã được hiển thị. Dữ liệu hiệu lực chỉ đọc.

## **So Sánh Các Giá Trị Cục Bộ, Kế Thừa và Hiệu Lực**

Ví dụ hoàn chỉnh sau tạo một shape và áp dụng chiều cao phông chữ ở mức trình chiếu, đoạn văn và phần. Mỗi bước in ra các giá trị được định nghĩa ở các mức và giá trị hiệu lực kết quả cho cùng một phần văn bản. Nó cũng minh họa lý do tại sao dữ liệu hiệu lực phải được đọc lại sau khi thay đổi định dạng.

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

            // Xác định các giá trị kế thừa ở hai cấp độ khác nhau.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Giá trị cục bộ trên phần sẽ ghi đè cả hai giá trị kế thừa.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Thay đổi giá trị kế thừa sẽ không ghi đè giá trị cục bộ hiện có.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Xóa giá trị cục bộ. Phần hiện sẽ kế thừa lại từ đoạn văn.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Xóa giá trị đoạn văn. Mặc định của bản trình chiếu bây giờ cung cấp kết quả.
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

        // Đọc dữ liệu hiệu lực sau các thay đổi trước đó.
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

Độ ưu tiên trong ví dụ này là định dạng cục bộ của phần, sau đó là định dạng đoạn văn, cuối cùng là mặc định của trình chiếu. Các đối tượng khác có thể có chuỗi kế thừa khác nhau, nhưng nguyên tắc vẫn giống: giá trị cụ thể hơn và được đặt rõ ràng sẽ thắng, và [getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/#getEffective--) trả về kết quả cuối cùng.

## **Lấy Các Thuộc Tính Văn Bản Hiệu Lực**

Định dạng văn bản được chia ra nhiều đối tượng:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#getEffective--) giải quyết các thuộc tính khung văn bản như lề, neo, tự động điều chỉnh và hướng văn bản dọc.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextstyle/#getEffective--) giải quyết định dạng đoạn văn cho mỗi mức kiểu văn bản.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getEffective--) giải quyết các thuộc tính đoạn văn như căn chỉnh, thụt lề và dấu chấm.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/#getEffective--) giải quyết các thuộc tính ký tự như chiều cao phông chữ, họ phông, màu, in đậm và in nghiêng.

Đối với ví dụ tiếp theo, tệp `text-formatting.pptx` phải chứa ít nhất một slide và một [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) có khung văn bản không rỗng. AutoShape có thể nằm ở bất kỳ vị trí nào trong bộ sưu tập shape; mã sẽ tìm đối tượng phù hợp và xác thực trước khi sử dụng.

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

## **Lấy Các Thuộc Tính 3D Hiệu Lực**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getEffective--) trả về một đối tượng [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformateffectivedata/) nhóm tất cả các cài đặt 3D đã được giải quyết. Các phương thức [getCamera](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), và [getBevelBottom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) cung cấp dữ liệu hiệu lực tương ứng. Đọc các cài đặt liên quan này cùng nhau giúp hiểu dễ hơn về diện mạo 3D cuối cùng của một shape.

Đối với ví dụ này, tệp `shape-3d.pptx` phải chứa ít nhất một shape trên slide đầu tiên. Áp dụng cài đặt camera 3D, ánh sáng hoặc bevel cho shape đó nếu bạn muốn kết quả bao gồm các giá trị khác với mặc định.

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

## **Lấy Định Dạng Bảng Hiệu Lực**

Định dạng bảng có thể đến từ kiểu bảng và từ các định dạng được áp dụng cho toàn bộ bảng, cột, hàng hoặc ô riêng lẻ. Khi có xung đột giữa các màu nền được xác định rõ, thứ tự ưu tiên là ô, hàng, cột, rồi toàn bộ bảng. Định dạng hiệu lực của một ô là định dạng cuối cùng được dùng để vẽ ô đó.

Đối với ví dụ này, tệp `table-formatting.pptx` phải chứa ít nhất một bảng trên slide đầu tiên. Bảng phải có ít nhất một hàng và một cột. Mã sẽ tìm một [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itable/) thay vì giả định rằng `getShapes().get_Item(0)` là một bảng.

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

Nếu bạn cần màu hơn chỉ kiểu nền, trước tiên kiểm tra [getFillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) trong dữ liệu hiệu lực, sau đó đọc phương thức áp dụng cho kiểu đó—ví dụ, [getSolidFillColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) cho nền đặc.

## **Đọc Lại Dữ Liệu Hiệu Lực Sau Khi Thay Đổi**

Dữ liệu hiệu lực mô tả chuỗi định dạng tại thời điểm nó được giải quyết. Gọi `getEffective` một lần nữa sau khi thay đổi bất kỳ yếu tố nào có thể tham gia vào chuỗi đó, bao gồm:

- định dạng cục bộ của đối tượng;
- mặc định đoạn văn hoặc khung văn bản;
- kiểu bảng, bảng, cột, hàng hoặc định dạng ô;
- định dạng bố cục hoặc slide master;
- dữ liệu chủ đề hoặc các mặc định ở mức trình chiếu;
- bố cục hoặc master được gán cho slide.

Không giữ một đối tượng dữ liệu hiệu lực như một bức ảnh chụp vĩnh viễn. Aspose.Slides có thể lưu bộ nhớ đệm một số dữ liệu hiệu lực nội bộ, và một lời gọi `getEffective` sau này có thể làm mới dữ liệu đó. Nếu bạn cần so sánh các giá trị trước và sau khi thay đổi, sao chép các giá trị vô hướng cần thiết—chẳng hạn chiều cao phông chữ, màu, căn chỉnh hoặc độ rộng bevel—vào biến của riêng bạn trước khi thực hiện thay đổi.

Để thay đổi một giá trị, cập nhật đối tượng định dạng cục bộ thích hợp rồi gọi `getEffective` để xác nhận kết quả. Các đối tượng dữ liệu hiệu lực tự chúng chỉ đọc.

## **FAQ**

**Làm thế nào tôi có thể biết cấp độ nào đã cung cấp giá trị hiệu lực?**

Dữ liệu hiệu lực chỉ chứa giá trị cuối cùng, không phải nguồn gốc của nó. Kiểm tra các đối tượng cục bộ áp dụng từ cấp độ cụ thể nhất ra ngoài. Đối với văn bản, có thể bao gồm phần, đoạn văn, khung văn bản, bố cục, master, chủ đề và các mặc định của trình chiếu. Các giá trị chưa xác định như `Float.NaN` hoặc `null` cho biết quá trình tìm kiếm tiếp tục sang cấp độ khác.

**Điều gì xảy ra khi không có cấp độ nào định nghĩa thuộc tính?**

Aspose.Slides sẽ giải quyết giá trị mặc định phù hợp của PowerPoint hoặc thư viện. Giá trị đã được giải quyết đó sẽ xuất hiện trong dữ liệu hiệu lực ngay cả khi không có đối tượng cục bộ nào định nghĩa rõ ràng.

**Tại sao một giá trị hiệu lực đôi khi bằng với giá trị cục bộ?**

Giá trị cục bộ đã thắng trong phép tính kế thừa. Điều này là bình thường khi thuộc tính được đặt rõ ràng trên đối tượng và không có quy tắc cụ thể hơn nào ghi đè lên nó.

**Khi nào tôi nên sử dụng dữ liệu cục bộ thay vì dữ liệu hiệu lực?**

Sử dụng dữ liệu cục bộ để kiểm tra hoặc chỉnh sửa một mức định dạng cụ thể. Sử dụng dữ liệu hiệu lực khi bạn cần kết quả hiển thị cuối cùng sau khi đã áp dụng kế thừa, quy tắc chủ đề và các kiểu áp dụng. Ví dụ **so sánh đầy đủ** ([compare-local-inherited-and-effective-values](#compare-local-inherited-and-effective-values)) minh họa cả hai trong cùng một quy trình làm việc.