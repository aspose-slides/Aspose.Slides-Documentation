---
title: Διαχείριση Κόμβων Σχήματος SmartArt σε Παρουσιάσεις με Python
linktitle: Κόμβος Σχήματος SmartArt
type: docs
weight: 30
url: /el/python-net/manage-smartart-shape-node/
keywords:
- Κόμβος SmartArt
- Υποκόμβος
- Προσθήκη κόμβου
- Θέση κόμβου
- Πρόσβαση σε κόμβο
- Αφαίρεση κόμβου
- Προσαρμοσμένη θέση
- Βοηθητικός κόμβος
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- Παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε PPT, PPTX και ODP με το Aspose.Slides for Python via .NET. Λάβετε σαφή παραδείγματα κώδικα και συμβουλές για βελτιστοποίηση των παρουσιάσεών σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt σε παρουσιάσεις PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και ορίζουν τη δομή του διαγράμματος. Το Aspose.Slides σάς επιτρέπει να εργάζεστε με αυτούς τους κόμβους SmartArt προγραμματιστικά: να προσθέτετε νέους κόμβους και υποκόμβους, να εισάγετε υποκόμβους σε συγκεκριμένη θέση, να προσπελάζετε υπάρχοντες κόμβους και να διαβάζετε το κείμενο, το επίπεδο και τη θέση τους.

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρείτε κόμβους, να εργάζεστε με υποκόμβους με βάση το δείκτη ή τη θέση, να μετατρέψετε έναν βοηθητικό κόμβο σε κανονικό, να ρυθμίσετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβου SmartArt, να ορίσετε μορφές γεμίσματος κόμβου και να δημιουργήσετε μια μικρογραφία για έναν υποκόμβο SmartArt.

## **Προσθήκη Κόμβου SmartArt**
Το Aspose.Slides for Python via .NET παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον ευκολότερο τρόπο. Ο παρακάτω κώδικας δείγματος θα σας βοηθήσει να προσθέσετε κόμβο και υποκόμβο μέσα σε σχήμα SmartArt.

- Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσία με σχήμα SmartArt.  
- Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  
- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε Typecast το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.  
- Προσθέστε έναν νέο Node στη συλλογή NodeCollection του σχήματος SmartArt και ορίστε το κείμενο στο TextFrame.  
- Τώρα, προσθέστε έναν υποκόμβο στον νεοπροστέθηκε Node του SmartArt και ορίστε το κείμενο στο TextFrame.  
- Αποθηκεύστε την Παρουσίαση.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Φορτώστε την επιθυμητή παρουσίαση
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Διασχίστε κάθε σχήμα στην πρώτη διαφάνεια
    for shape in pres.slides[0].shapes:

        # Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if type(shape) is art.SmartArt:
            # Προσθήκη νέου κόμβου SmartArt
            node1 = shape.all_nodes.add_node()
            # Προσθήκη κειμένου
            node1.text_frame.text = "Test"

            # Προσθήκη νέου υποκόμβου στον γονικό κόμβο. Θα προστεθεί στο τέλος της συλλογής
            new_node = node1.child_nodes.add_node()

            # Προσθήκη κειμένου
            new_node.text_frame.text = "New Node Added"

    # Αποθήκευση Παρουσίασης
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Προσθήκη Κόμβου SmartArt σε Συγκεκριμένη Θέση**
Στον παρακάτω κώδικα δείγματος εξηγούμε πώς να προσθέσετε τους υποκόμβους που ανήκουν σε αντίστοιχους κόμβους του σχήματος SmartArt σε συγκεκριμένη θέση.

- Δημιουργήστε μια παρουσία της κλάσης `Presentation`.  
- Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Προσθέστε ένα σχήμα SmartArt τύπου StackedList στη διαφάνεια που προσπεράστηκε.  
- Προσπελάστε τον πρώτο κόμβο στο προστεθέν σχήμα SmartArt.  
- Τώρα, προσθέστε τον υποκόμβο για τον επιλεγμένο κόμβο στη θέση 2 και ορίστε το κείμενό του.  
- Αποθηκεύστε την Παρουσίαση.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Δημιουργία παρουσίασης
with slides.Presentation() as pres:
    # Πρόσβαση στη διαφάνεια της παρουσίασης
    slide = pres.slides[0]

    # Προσθήκη Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Πρόσβαση στον κόμβο SmartArt στη θέση 0
    node = smart.all_nodes[0]

    # Προσθήκη νέου υποκόμβου στη θέση 2 στον γονικό κόμβο
    chNode = node.child_nodes.add_node_by_position(2)

    # Προσθήκη κειμένου
    chNode.text_frame.text = "Sample text Added"

    # Αποθήκευση Παρουσίασης
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Πρόσβαση σε Κόμβο SmartArt**
Ο παρακάτω κώδικας δείγματος θα σας βοηθήσει να προσπελάσετε κόμβους μέσα σε σχήμα SmartArt. Παρακαλούμε σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν προστίθεται το σχήμα SmartArt.

- Δημιουργήστε μια παρουσία της κλάσης `Presentation` και φορτώστε την παρουσία με σχήμα SmartArt.  

- Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  

- Περιηγηθείτε σε κάθε σχήμα μέσα στην πρώτη διαφάνεια.  

- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε Typecast το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.  

- Περιηγηθείτε σε όλους τους Nodes μέσα στο σχήμα SmartArt.  

- Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση του κόμβου SmartArt, το επίπεδο και το κείμενο.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traverse through all nodes inside SmartArt
            for i in range(len(shape.all_nodes)):
                # Accessing SmartArt node at index i
                node = shape.all_nodes[i]

                # Printing the SmartArt node parameters
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **Access SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- For every selected SmartArt shape Node, traverse through all Child Nodes inside particular node.
- Access and display information like Child Node position, level and Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traverse through all nodes inside SmartArt
            for node0 in shape.all_nodes:
                # Traversing through the child nodes
                for j in range(len(node0.child_nodes)):
                    # Accessing the child node in SmartArt node
                    node = node0.child_nodes[j]

                    # Printing the SmartArt child node parameters
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **Access SmartArt Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape.
- Access the added SmartArt shape.
- Access the node at index 0 for accessed SmartArt shape.
- Now, access the Child Node at position 1 for accessed SmartArt node using GetNodeByPosition() method.
- Access and display information like Child Node position, level and Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instantiate the presentation
with slides.Presentation() as pres:
    # Accessing the first slide
    slide = pres.slides[0]
    # Adding the SmartArt shape in first slide
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Accessing the SmartArt  node at index 0
    node = smart.all_nodes[0]
    # Accessing the child node at position 1 in parent node
    position = 1
    chNode = node.child_nodes[position] 
    # Printing the SmartArt child node parameters
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **Remove SmartArt Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check if the SmartArt has more than 0 nodes.
- Select the SmartArt node to be deleted.
- Now, remove the selected node using RemoveNode() method* Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Typecast shape to SmartArtEx
            if len(shape.all_nodes) > 0:
                # Accessing SmartArt node at index 0
                node = shape.all_nodes[0]

                # Removing the selected node
                shape.all_nodes.remove_node(node)

    # save Presentation
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Remove SmartArt Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Select the SmartArt shape node at index 0.
- Now, check if the selected SmartArt node has more than 2 child nodes.
- Now, remove the node at Position 1 using RemoveNodeByPosition() method.
- Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Typecast shape to SmartArt
            if len(shape.all_nodes) > 0:
                # Accessing SmartArt node at index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Removing the child node at position 1
                    node.child_nodes.remove_node(1)

    # save Presentation
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Custom Position for Child Node in SmartArt**
Now Aspose.Slides for Python via .NET support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Move SmartArt shape to new position
	node = smart.all_nodes[1]
 shape = node.shapes[1]
 shape.x += (shape.width * 2)
 shape.y -= (shape.height / 2)

	# Change SmartArt shape's widths
	node = smart.all_nodes[2]
 shape = node.shapes[1]
 shape.width += (shape.width / 2)

	# Change SmartArt shape's height
	node = smart.all_nodes[3]
 shape = node.shapes[1]
 shape.height += (shape.height / 2)

	# Change SmartArt shape's rotation
	node = smart.all_nodes[4]
 shape = node.shapes[1]
 shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **Check Assistant Node**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of second slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes.
- Change the status of Assistant Node to normal node.
- Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Creating a presentation instance
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traversing through all nodes of SmartArt shape
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Check if node is Assitant node
                if node.is_assistant:
                    # Setting Assitant node to false and making it normal node
                    node.is_assistant = False
    # save Presentation
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Node's Fill Format**
Aspose.Slides for Python via .NET makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Python via .NET.

Please follow the steps below:

- Create an instance of the `Presentation` class.
- Obtain the reference of a slide using its index.
- Add a SmartArt shape by setting its LayoutType.
- Set the FillFormat for the SmartArt shape nodes.
- Write the modified presentation as a PPTX file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accessing the slide
    slide = presentation.slides[0]

    # Adding SmartArt shape and nodes
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Setting node fill color
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Saving Presentation
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Generate Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate `Presentation` class that represents the PPTX file.
1. Add SmartArt.
1. Obtain the reference of a node by using its Index
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

The example below generating a thumbnail of SmartArt child node

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instantiate Presentation class that represents the PPTX file 
with slides.Presentation() as presentation: 
    # Add SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obtain the reference of a node by using its Index  
    node = smart.nodes[1]

    # Get thumbnail
    with node.shapes[0].get_image() as bmp:
        # save thumbnail
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**Υποστηρίζεται η κίνηση SmartArt;**

Ναι. Το SmartArt αντιμετωπίζεται ως κανονικό σχήμα, έτσι μπορείτε να [εφαρμόσετε τυπικές κινήσεις](/slides/el/python-net/shape-animation/) (εισόδους, εξόδους, έμφαση, διαδρομές κίνησης) και να ρυθμίσετε το χρόνο. Μπορείτε επίσης να κινήσετε σχήματα μέσα σε κόμβους SmartArt όταν χρειάζεται.

**Πώς μπορώ να εντοπίσω αξιόπιστα ένα συγκεκριμένο SmartArt σε μια διαφάνεια εάν το εσωτερικό του ID δεν είναι γνωστό;**

Αναθέστε και αναζητήστε με βάση το [εναλλακτικό κείμενο](/slides/el/python-net/shape-animation/) (alternative text). Ορίζοντας ένα χαρακτηριστικό AltText στο SmartArt, μπορείτε να το βρείτε προγραμματιστικά χωρίς να βασίζεστε σε εσωτερικά αναγνωριστικά.

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;**

Ναι. Το Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [εξαγωγή PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), διατηρώντας τη διάταξη, τα χρώματα και τα εφέ.

**Μπορώ να εξάγω εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή αναφορές);**

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [αργά μορφές](/slides/el/python-net/convert-powerpoint-to-pdf/) ή σε [SVG](/slides/el/python-net/convert-powerpoint-to-pdf/) για εξαγωγή διανυσματικού τύπου, καθιστώντας το κατάλληλο για μικρογραφίες, αναφορές ή χρήση στο διαδίκτυο.