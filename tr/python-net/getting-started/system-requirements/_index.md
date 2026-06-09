---
title: Sistem Gereksinimleri
type: docs
weight: 60
url: /tr/python-net/system-requirements/
keywords:
- sistem gereksinimleri
- işletim sistemi
- kurulum
- bağımlılıklar
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET sistem gereksinimlerini keşfedin. Windows, Linux ve macOS üzerinde sorunsuz PowerPoint ve OpenDocument desteği sağlayın."
---
## **Giriş**

Aspose.Slides for Python via .NET, Microsoft PowerPoint gibi üçüncü taraf ürünlerin yüklü olmasını gerektirmez. Aspose.Slides, Microsoft PowerPoint sunum formatları dahil çeşitli formatlarda belge oluşturma, değiştirme, dönüştürme ve renderleme motorudur.

## **Desteklenen İşletim Sistemleri**

Aspose.Slides for Python, Windows (32‑bit ve 64‑bit), macOS ve Python 3.5 ya da daha yeni bir sürümü kurulu olan 64‑bit Linux sistemlerini destekler.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">İşletim Sistemi</td>
        <td style="font-weight: bold; width:400px">Sürümler</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>ve diğerleri</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Hedef Linux ve macOS Platformları için Sistem Gereksinimleri**

- GCC 6 çalışma zamanı kütüphaneleri (veya daha yenisi).
- [libgdiplus](https://github.com/mono/libgdiplus), GDI+ API'sinin açık kaynaklı bir uygulaması.
- .NET Core Runtime bağımlılıkları. .NET Core Runtime'ın kendisinin kurulması GEREKMEZ.
- Python 3.5–3.7 için: `pymalloc` derlemesi gereklidir. `--with-pymalloc` derleme seçeneği varsayılan olarak etkindir. Genellikle, `pymalloc` derlemesi dosya adının sonunda `m` eki bulunur.
- `libpython` paylaşımlı kütüphanesi. `--enable-shared` Python derleme seçeneği varsayılan olarak devre dışıdır ve bazı Python dağıtımları `libpython` paylaşımlı kütüphanesini içermez. Bazı Linux platformlarında, paket yöneticisi aracılığıyla `libpython` paylaşımlı kütüphanesini kurabilirsiniz (örnek, `sudo apt-get install libpython3.7`). Yaygın bir sorun, `libpython` kütüphanesinin paylaşımlı kütüphaneler için standart olmayan bir konuma kurulmuş olmasıdır. Bu durumu, Python derleme seçenekleriyle alternatif kütüphane yollarını belirleyerek veya `libpython` kütüphane dosyasına sistemin standart paylaşımlı kütüphane konumunda sembolik bir link oluşturarak çözebilirsiniz. Genellikle, `libpython` paylaşımlı kütüphane dosya adı Python 3.5–3.7 için `libpythonX.Ym.so.1.0`, Python 3.8 ve sonrası için `libpythonX.Y.so.1.0` şeklindedir (örnek, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **SSS**

**Dönüştürme ve renderleme için Microsoft PowerPoint yüklü olması gerekiyor mu?**

Hayır, PowerPoint gerekli değildir; Aspose.Slides, sunumları [creating](/slides/tr/python-net/create-presentation/), değiştirme, [converting](/slides/tr/python-net/convert-presentation/) ve [rendering](/slides/tr/python-net/convert-powerpoint-to-png/) için bağımsız bir motorudur.

**Makinede belirli bir .NET sürümü (Core/5+/6+) gerekli mi?**

.NET Runtime'ın kendisinin kurulması gerekmez, ancak bağımlılıkları Linux/macOS üzerinde bulunmalıdır. Bu, .NET bağımlılıkları olarak genellikle kurulan paketlerin sistemde bulunması, runtime'ın tamamen kurulması anlamına gelmez.

**Doğru renderleme için hangi yazı tipleri gerekir?**

Uygulamada kullanılan yazı tipleri veya uygun [substitutes](/slides/tr/python-net/font-substitution/) bulunmalıdır. Linux/macOS üzerinde tutarlı renderleme sağlamak için yaygın yazı tipi paketlerinin kurulması önerilir.

**Özel bir yazı tipi Linux’ta yedek ya da eksik metin olarak render ediliyor, neden?**

Yazı tipi dosyasının isim tablosu girdileri tutarsız ya da bozuksa, Linux yazı tipi eşleme yığını (FreeType/fontconfig) geçersiz bir kaydı seçebilir ve yazı tipi çözülemez. Düzeltmiş isim tablosu girdilerine sahip bir sürüm kullanmak veya tutarlı bir yedek kurmak sorunu çözer.