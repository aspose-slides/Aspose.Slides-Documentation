---
title: संस्करण 26.8 में नए Python‑to‑.NET इंजन में प्रवास करें
linktitle: नए इंजन में प्रवास करें
type: docs
weight: 290
url: /hi/python-net/migrate-to-new-engine/
keywords:
- नया इंजन
- प्रवासन
- aspose.pydrawing
- ड्राइंग प्रिमिटिव्स
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- पायथन
- Aspose.Slides
description: "अपने पायथन कोड को संस्करण 26.8 के नए Aspose.Slides इंजन में ले जाएँ: ड्राइंग प्रिमिटिव्स को aspose.slides में स्थानांतरित करें, और आयातों को स्वचालित रूप से ठीक करें।"
---
## **परिचय**

संस्करण 26.8 Python को .NET से जोड़ने वाले इंजन को प्रतिस्थापित करता है। ड्राइंग प्रिमिटिव्स `aspose.slides` मॉड्यूल में स्थानांतरित किए गए हैं।

यदि अपडेट के बाद आपको समस्याएँ आती हैं तो सीधे [मेरे पास त्रुटि है](#i-have-an-error) पर जाएँ।

### **ड्राइंग प्रिमिटिव्स aspose.slides में स्थानांतरित किए गए**

सात प्रकार स्थानांतरित हुए। इनके नाम, तर्क और व्यवहार अपरिवर्तित रहता है:

|प्रकार|26.8 से पहले|26.8 और बाद में|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/hi/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/hi/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/color/)|

इन सात प्रकारों ने `aspose.pydrawing` की पूरी शेष सामग्री बना ली थी। एक बार इन्हें पुनः निर्देशित करने के बाद आपके कोड में `aspose.pydrawing` का कोई संदर्भ रखने की आवश्यकता नहीं रहती, और सभी इम्पोर्ट को हटा दिया जा सकता है। यह परिणाम की जाँच को भी आसान बनाता है — देखें [स्थलांतरण की जाँच करें](#verify-the-migration)।

**पुराना कोड:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.red

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

**संस्करण 26.8:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    with slide.get_image(slides.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

`from` आयात रूप उसी तरह बदलता है:

```python
# पुराना कोड
from aspose.pydrawing import Color, Point

# संस्करण 26.8
from aspose.slides import Color, Point
```

## **आयात त्रुटि को ठीक करें**

पहले कॉलम में अपना ट्रेसबैक खोजें।

|त्रुटि|कारण|सुधार|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (या `Point`, `Rectangle`, आदि)|पैकेज 26.8 है, कोड अभी भी पुराने मॉड्यूल की ओर इशारा कर रहा है|[कोड अपडेट करें](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|उसी कारण से, `from` आयात रूप|[कोड अपडेट करें](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|मॉड्यूल और उसके सभी सात प्रकार `aspose.slides` में स्थानांतरित हो गए हैं|[कोड अपडेट करें](#update-your-code), फिर `aspose.pydrawing` इम्पोर्ट को हटा दें|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|कोड माइग्रेट किया गया, लेकिन स्थापित पैकेज 26.7 या उससे पुराना है|`pip install --upgrade aspose.slides`|
|`TypeError` किसी रंग, बिंदु या आकार तर्क पर|`aspose.pydrawing` से बना मान नए API को पास किया गया है|`aspose.slides` से भी वही मान बनाएं|

## **अपना कोड अपडेट करें**

क्योंकि `aspose.pydrawing` में केवल सात स्थानांतरित प्रकार ही बचते हैं, स्थलांतरण केवल मॉड्यूल के नाम बदलने के बराबर है। सभी आयात रूप इस एकल रीनेम से कवर हो जाते हैं, जिसमें उपनाम भी शामिल हैं:

```python
# पुराना कोड
import aspose.pydrawing as drawing
color = drawing.Color.red

# संस्करण 26.8 - उपनाम काम करता रहता है
import aspose.slides as drawing
color = drawing.Color.red
```

यह किसी भी स्कोप में मान्य है, यहाँ तक कि फ़ंक्शन बॉडी के भीतर भी, क्योंकि उपनाम उसी स्थान पर बंधा रहता है जहाँ पहले बंधा था। एक ही कमी यह है कि नाम थोड़ा भ्रामक है, इसलिए स्पष्ट इरादा दर्शाने पर विचार करें:

```python
import aspose.slides as slides
color = slides.Color.red
```

कोड बेस के आकार के अनुसार उपयुक्त दृष्टिकोण चुनें।

### **हाथ से बदलें**

कुछ फ़ाइलों के लिए `aspose.pydrawing` को खोजें और `aspose.slides` से बदलें, फिर अब आवश्यक नहीं रहे इम्पोर्ट को हटा दें।

### **Shell कमांड के साथ बदलें**

यह साधारण टेक्स्ट प्रतिस्थापन है, इसलिए यह स्ट्रिंग और टिप्पणी में मौजूद घटनाओं को भी बदल देगा। दोनों कमांड प्रत्येक फ़ाइल की `.bak` प्रतिलिपि बनाते हैं।

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

macOS पर, `sed -i ''` का उपयोग करें `sed -i.bak` के बजाय, या GNU sed को `gsed` के रूप में स्थापित करें।

**Windows PowerShell:**

```
Get-ChildItem -Recurse -Filter *.py | ForEach-Object {
  $t = Get-Content $_ -Raw
  $new = $t -replace 'aspose\.pydrawing', 'aspose.slides'
  if ($new -ne $t) {
    Copy-Item $_.FullName "$($_.FullName).bak"
    Set-Content $_.FullName $new -NoNewline
    $_.FullName
  }
}
```

Linux या macOS पर वापस लौटने के लिए:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Windows पर वापस लौटने के लिए:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Python स्क्रिप्ट के साथ बदलें**

इसी रीनेम को लागू करने वाला पोर्टेबल स्क्रिप्ट, Linux, macOS और Windows सभी पर работает। स्क्रिप्ट पथ को तर्क के रूप में लेती है और `--write` न पास करने पर परिवर्तन का पूर्वावलोकन दिखाती है। परिवर्तन को लिखने के लिए `--write` और बैकअप बनाने के लिए `--backup` जोड़ें। इसे कोई भी नाम दें — उपयोग संदेश रन‑टाइम पर नाम लेता है।

```python
"""aspose.pydrawing को aspose.slides में पुनःनामित करें। साधारण पाठ प्रतिस्थापन।

    python <this script> src/                     # पूर्वावलोकन
    python <this script> src/ --write             # लागू करें
    python <this script> src/ --write --backup    # लागू करें, .bak प्रतियों को रखकर
"""

import sys
from pathlib import Path

W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0

for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    n = s.replace("aspose.pydrawing", "aspose.slides")
    if n == s:
        continue
    changed += 1
    print(("wrote " if W else "would change ") + str(p))
    if W:
        if B:
            p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
        p.write_text(n, encoding="utf-8")

print(f"{changed} file(s) {'changed' if W else 'to change'}"
      + ("" if W or not changed else "; rerun with --write to apply"))
```

एक सामान्य रन इस प्रकार दिखता है:

```console
$ python migrate.py src/
would change src/render.py
would change src/export/slides.py
2 file(s) to change; rerun with --write to apply

$ python migrate.py src/ --write --backup
wrote src/render.py
wrote src/export/slides.py
2 file(s) changed
```

पथ एक डायरेक्टरी हो सकता है, जिसे पुनरावर्ती रूप से दौड़ाया जाता है, या एकल `.py` फ़ाइल।

### **AST-आधारित स्क्रिप्ट के साथ बदलें**

बड़े कोड बेस के लिए अनुशंसित। यह स्क्रिप्ट वही रीनेम करती है, लेकिन पहले प्रत्येक फ़ाइल को पार्स करती है, इसलिए स्ट्रिंग, टिप्पणी या डॉकस्ट्रिंग में मौजूद घटनाएँ नहीं छूती।

क्योंकि यह मॉड्यूल को इन‑प्लेस रीनेम करता है और उपनाम को अपरिवर्तित छोड़ता है, सभी आयात रूप बिना विशेष मामलों के संभाले जाते हैं: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, मल्टी‑लाइन पैरेंथेसाइज़्ड इम्पोर्ट, फ़ंक्शन के भीतर इम्पोर्ट, और मॉड्यूल को मान के रूप में पास करना। यह वही `--write` और `--backup` फ्लैग स्वीकार करता है।

```python
"""Rename aspose.pydrawing to aspose.slides, skipping strings and comments.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import ast, sys
from pathlib import Path

MOD, DST = "aspose.pydrawing", "aspose.slides"
W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def fix(src):
    tree = ast.parse(src)
    off, o = [], 0
    for l in src.encode().splitlines(keepends=True):
        off.append(o)
        o += len(l)
    off.append(o)
    edits = []

    for n in ast.walk(tree):
        # import aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # मॉड्यूल नाम को स्थान पर ही पुनःनामित किया जाता है, इसलिए कोई भी उपनाम पहले की तरह बंधा रहेगा।
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Any expression referring to the module, including bare `fn(aspose.pydrawing)`.
        # किसी भी अभिव्यक्ति जो मॉड्यूल को संदर्भित करती है, जिसमें सरल `fn(aspose.pydrawing)` भी शामिल है।
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # back to front keeps offsets valid
        # पीछे से आगे की ओर बदलने से ऑफ़सेट वैध रहते हैं
        b = b[:s] + r.encode() + b[e:]
    return b.decode()


for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    try:
        n = fix(s)
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    if n != s:
        print(("wrote " if W else "would change ") + str(p))
        if W:
            if B:
                p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
            p.write_text(n, encoding="utf-8")
```

दोनों स्क्रिप्ट आईडेम्पोटेंट हैं: माइग्रेटेड कोड पर फिर चलाने से कुछ नहीं बदलता।

## **स्थलांतरण की जाँच करें**

एक टेक्स्ट खोज दिखाती है कि क्या कुछ बचा है:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

यह तेज़ है, लेकिन यह स्ट्रिंग और टिप्पणी में भी मिलती है, इसलिए साफ़ कोड भी हिट कर सकता है। निश्चित उत्तर के लिए नीचे दिया गया चेक उपयोग करें। यह केवल वास्तविक कोड संदर्भों की रिपोर्ट करता है और यदि कोई बचे हों तो गैर‑शून्य स्थिति के साथ बाहर निकलता है, जिससे इसे बिल्ड‑गेट के रूप में उपयोग किया जा सकता है।

```python
import ast, sys
from pathlib import Path

MOD = "aspose.pydrawing"
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), ".")


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def scan(tree):
    for n in ast.walk(tree):
        if isinstance(n, ast.Import) and any(a.name == MOD for a in n.names):
            yield n.lineno, f"import {MOD}"
        elif isinstance(n, ast.ImportFrom) and n.module == MOD:
            names = ", ".join(a.name for a in n.names)
            yield n.lineno, f"from {MOD} import {names}"
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            yield n.lineno, f"reference to {MOD}"


hits = 0
for p in sorted(Path(ROOT).rglob("*.py")):
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    try:
        tree = ast.parse(p.read_text(encoding="utf-8"))
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    for lineno, what in sorted(scan(tree)):
        print(f"{p}:{lineno}: {what}")
        hits += 1

print("migration complete" if not hits else f"{hits} reference(s) left")
sys.exit(1 if hits else 0)
```

स्थलांतरण से पहले और बाद में इसे चलाएँ:

```console
$ python verify.py src/
src/render.py:4: from aspose.pydrawing import Color, Point
src/render.py:11: import aspose.pydrawing
src/render.py:12: reference to aspose.pydrawing
3 reference(s) left

$ python migrate.py src/ --write
wrote src/render.py

$ python verify.py src/
migration complete
```

अंत में, एक स्मोकी टेस्ट चलाएँ जो स्थानांतरित प्रकारों को एक्सरसाइज़ करे:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("smoke.pptx", slides.export.SaveFormat.PPTX)
    print("OK")
```

## **अनुशंसित स्थलांतरण क्रम**

1. **एक बेसलाइन रखें।** वर्तमान संस्करण पर अपने परीक्षण चलाएँ और रेफ़रेंस रेंडर रखें। इससे स्थलांतरण त्रुटियों को रेंडरिंग अंतर से अलग किया जा सकेगा।
2. **स्थलांतरण का पूर्वावलोकन करें।** `--write` के बिना किसी स्क्रिप्ट को चलाएँ और उन फ़ाइलों की सूची की समीक्षा करें जिन्हें यह बदलने वाला है।
3. **लागू करें और जाँचें।** `--write --backup` के साथ चलाएँ, फिर सत्यापन स्क्रिप्ट और स्मोकी टेस्ट चलाएँ।
4. **रेंडर की तुलना सहनशीलता के साथ करें।** .NET 6 बिल्ड में बदलाव के कारण टेक्स्ट और इफ़ेक्ट्स में छोटे अंतर आ सकते हैं। बाइट‑फॉर‑बाइट तुलना के बजाय थ्रेसहोल्ड‑आधारित तुलना का उपयोग करें।
5. **बैकअप हटाएँ।** परिणाम की पुष्टि होने के बाद `.bak` फ़ाइलें हटाएँ: Linux/macOS पर `find . -name '*.py.bak' -delete`, Windows पर `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item`।

## **एक कोड बेस में दोनों संस्करणों का समर्थन करें**

यदि आपको समान स्रोत से 26.7 और 26.8 दोनों पर चलाना है:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 और बाद में
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 और पहले
```

## **जो नहीं बदला**

- स्थानांतरित प्रिमिटिव्स के नाम, तर्क और व्यवहार।
- `aspose.slides` API का शेष हिस्सा।
- लाइसेंसिंग और लाइसेंस फ़ाइल लागू करने का तरीका।
- फ़ाइल फ़ॉर्मेट और सहेजने‑लोड करने का व्यवहार।
- Windows और macOS पर सिस्टम आवश्यकताएँ।
- अलग .NET इंस्टॉलेशन की अनुपस्थिति — रन‑टाइम अभी भी बंडलेड है।